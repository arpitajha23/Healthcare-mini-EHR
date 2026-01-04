using DomainLayer.DTOs.DoctorAppointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IService
{
    public interface IDoctorAppointmentsService
    {
        Task<DoctorAppointmentStatsDto> GetTodayAppointmentCountAsync(int doctorId);
        Task<int> GetTodayCompletedCountAsync(int doctorId);
        Task<int> GetTodayOnlineCountAsync(int doctorId);
        Task<int> GetTodayOfflineCountAsync(int doctorId);
        Task<List<DoctorAppointmentListDto>> GetDoctorAppointmentsAsync(DoctorAppointmentQueryDto dto);

    }
}
