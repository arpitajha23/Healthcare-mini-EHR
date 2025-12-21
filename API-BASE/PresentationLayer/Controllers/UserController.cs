using ApplicationLayer.IService;
using DomainLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail(string email, string role)
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

    }
}
