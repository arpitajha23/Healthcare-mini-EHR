using ApplicationLayer.IService;
using ApplicationLayer.Service;
using DomainLayer.DTOs;
using DomainLayer.DTOs.PatientDTOs;
using DomainLayer.CommonMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Security.Claims;
using DataAccessLayer.Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;
        public UserController(IUserService userService, IEmailService emailService, IJwtService jwtService)
        {
            _userService = userService;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail(string email, int role)
        {
            var result = await _userService.GetUserByEmailAsync(email, role);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _userService.RoleBaseRegisterAsync(dto);
                return Ok(new { message = "Patient registered successfully", user = result });
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset(UserPasswordResetRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _userService.RequestPasswordResetAsync(dto);
            return Ok(new { message = "If that account exists, a reset link has been sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userService.ResetPasswordAsync(dto);
                return Ok(new { message = "Password reset successful." });
            }
            catch (SecurityException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required");

            var response = await _userService.VerifyEmailAsync(request.Email);

            return Ok(response);
        }

        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOtp([FromBody] ResendOtpRequest request)
        {
            if (request.UserId == 0)
                return BadRequest("UserId is required"); 

            await _userService.SendLoginOtpAsync(request.UserId);

            return Ok(new
            {
                message = "OTP sent successfully",
                userId = request.UserId
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(PatientLoginRequestDto request)
        {
            var user = await _userService.GetUserByEmailandRole(request.Email, request.Role);

            if (user == null)
                return Unauthorized("Invalid credentials");

            if (!PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            if (!user.IsActive || user.IsLocked == true)
                return Forbid("Account is inactive or locked");

            // Send OTP (Login OTP Type)
            await _userService.SendLoginOtpAsync(user.UserId);

            return Ok(new
            {
                message = "OTP sent successfully",
                userId = user.UserId,
                email = user.Email
            });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
        {
            var otpValid = await _userService.VerifyLoginOtpAsync(request.UserId, request.Otp);

            if (otpValid == null)
                return BadRequest("Invalid or expired OTP");

            var claims = new Dictionary<string, string>
            {
                { ClaimTypes.NameIdentifier, otpValid.UserId.ToString() },
                { ClaimTypes.Email, otpValid.Email },
                { ClaimTypes.Name, $"{otpValid.FullName}" },
                { ClaimTypes.Role, otpValid.RoleId.ToString()}
            };

            var token = _jwtService.GenerateToken(claims, 60);

            return Ok(new { token, message = "Login successful" });
        }


    }
}
