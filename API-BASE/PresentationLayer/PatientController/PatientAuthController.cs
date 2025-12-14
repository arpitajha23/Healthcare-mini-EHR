using ApplicationLayer.IService;
using DomainLayer.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace PresentationLayer.PatientController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthController : ControllerBase
    {
        private readonly IPatientAuthService _patientAuthService;
        public PatientAuthController(IPatientAuthService patientAuthService)
        {
            _patientAuthService = patientAuthService;
        }

        //Login
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody]PatientLoginRequestDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        //        var response = await _patientAuthService.LoginAsync(dto, ip);
        //        return Ok(new { message = "Login successful", data = response });
        //    }
        //    catch (SecurityException ex)
        //    {
        //        return Unauthorized(new { message = ex.Message });
        //    }
        //}


    }
}
