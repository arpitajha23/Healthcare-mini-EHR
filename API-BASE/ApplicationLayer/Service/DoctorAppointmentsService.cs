using ApplicationLayer.IService;
using DomainLayer.DTOs.DoctorAppointments;
using InfrastructureLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class DoctorAppointmentsService : IDoctorAppointmentsService
    {
        private readonly IDoctorAppointmentsRepository _doctorRepository;
        public DoctorAppointmentsService(IDoctorAppointmentsRepository doctorAppointmentsRepository)
        {
            _doctorRepository = doctorAppointmentsRepository;
        }
        public async Task<DoctorAppointmentStatsDto> GetTodayAppointmentCountAsync(int doctorId)
        {
            var count = await _doctorRepository
                .GetTodayAppointmentCountAsync(doctorId);

            return new DoctorAppointmentStatsDto
            {
                TodayTotalAppointments = count
            };
        }
        public async Task<int> GetTodayCompletedCountAsync(int doctorId)
        {
            return await _doctorRepository.GetTodayCompletedCountAsync(doctorId);
        }

        public async Task<int> GetTodayOnlineCountAsync(int doctorId)
        {
            return await _doctorRepository.GetTodayOnlineCountAsync(doctorId);
        }

        public async Task<int> GetTodayOfflineCountAsync(int doctorId)
        {
            return await _doctorRepository.GetTodayOfflineCountAsync(doctorId);
        }

        public async Task<List<DoctorAppointmentListDto>> GetDoctorAppointmentsAsync(DoctorAppointmentQueryDto dto)
        {
            return await _doctorRepository.GetDoctorAppointmentsAsync(dto);
        }


    }
}
