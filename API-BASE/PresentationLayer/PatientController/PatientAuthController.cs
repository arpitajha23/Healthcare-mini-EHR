using ApplicationLayer.IService;
using ApplicationLayer.Service;
using DataAccessLayer.Models;
using DomainLayer.CommonMethod;
using DomainLayer.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Security.Claims;

namespace PresentationLayer.PatientController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthController : ControllerBase
    {
        private readonly IPatientAuthService _patientAuthService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;
        public PatientAuthController(IPatientAuthService patientAuthService, IUserService userService, IEmailService emailService, IJwtService jwtService)
        {
            _patientAuthService = patientAuthService;
            _userService = userService;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(PatientLoginRequestDto request)
        //{
        //    var user = await _userService.GetUserByEmailandRole(request.Email, request.Role);

        //    if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
        //        return Unauthorized("Invalid credentials");
        //    // Generate OTP
        //    await _userService.SendLoginOtpAsync(user.UserId);
        //    return Ok(new { message = "OTP sent", userId = user.UserId });
        //}

        //[HttpPost("verify-otp")]
        //public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
        //{
        //    var otpValid = await _userService.VerifyLoginOtpAsync(request.UserId, request.Otp);

        //    if (otpValid == null)
        //        return BadRequest("Invalid or expired OTP");

        //    var claims = new Dictionary<string, string>
        //    {
        //        { ClaimTypes.NameIdentifier, otpValid.UserId.ToString() },
        //        { ClaimTypes.Email, otpValid.Email },
        //        { ClaimTypes.Name, $"{otpValid.FullName}" },
        //        { ClaimTypes.Role, otpValid.Role }
        //    };

        //    var token = _jwtService.GenerateToken(claims, 60);


        //    return Ok(new{ token, message = "Login successful" });
        //}


    }
}
