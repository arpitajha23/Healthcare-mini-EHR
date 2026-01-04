using ApplicationLayer.IService;
using ApplicationLayer.Service;
using DomainLayer.DTOs.DoctorAppointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.DoctorController
{
    [ApiController]
    [Route("api/doctor")]
    //[Authorize(Roles = "Doctor")]
    public class DoctorAppointmentsController :  ControllerBase
    {
        private readonly IDoctorAppointmentsService _doctorService;

        public DoctorAppointmentsController(IDoctorAppointmentsService doctorService)
        {
            _doctorService = doctorService;
        }

        //[Authorize]
        [HttpGet("today/count")]
        public async Task<IActionResult> GetTodayAppointmentCount([FromQuery] int doctorId)
        {
            if (doctorId <= 0)
                return BadRequest("Invalid doctorId");

            var result = await _doctorService
                .GetTodayAppointmentCountAsync(doctorId);

            return Ok(new
            {
                todayTotalAppointments = result.TodayTotalAppointments
            });

        }

        //[Authorize]
        [HttpGet("today/completed")]
        public async Task<IActionResult> GetTodayCompleted([FromQuery] int doctorId)
        {
            var count = await _doctorService.GetTodayCompletedCountAsync(doctorId);
            return Ok(new { count });
        }

        ////[Authorize]
        [HttpGet("today/online")]
        public async Task<IActionResult> GetTodayOnline([FromQuery] int doctorId)
        {
            var count = await _doctorService.GetTodayOnlineCountAsync(doctorId);
            return Ok(new { count });
        }

        //[Authorize]
        [HttpGet("today/offline")]
        public async Task<IActionResult> GetTodayOffline([FromQuery] int doctorId)
        {
            var count = await _doctorService.GetTodayOfflineCountAsync(doctorId);
            return Ok(new { count });
        }
        //[Authorize]
        [HttpGet("appointments/list")]
        public async Task<IActionResult> GetDoctorAppointments([FromQuery] DoctorAppointmentQueryDto query)
        {
            var data = await _doctorService.GetDoctorAppointmentsAsync(query);

            return Ok(new
            {
                data,
                totalRecords = data.FirstOrDefault()?.total_records ?? 0
            });
        }


    }
}
