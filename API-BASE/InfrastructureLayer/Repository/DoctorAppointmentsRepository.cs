using Dapper;
using DomainLayer.Dapper;
using DomainLayer.DTOs.DoctorAppointments;
using InfrastructureLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Enums.Enums;

namespace InfrastructureLayer.Repository
{
    public class DoctorAppointmentsRepository : IDoctorAppointmentsRepository
    {
        private readonly DapperContext _dapperContext;
        public DoctorAppointmentsRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> GetTodayAppointmentCountAsync(int doctorId)
        {
            using var connection = _dapperContext.CreateConnection();

            var sql = @"
                SELECT COUNT(*)
                FROM appointments
                WHERE doctor_id = @DoctorId
                  AND status_id <> @RejectedStatus
                  AND DATE(appointment_date) = CURRENT_DATE;
            ";

            return await connection.ExecuteScalarAsync<int>(sql, new
            {
                DoctorId = doctorId,
                RejectedStatus = (int)AppointmentStatus.Rejected
            });
        }

        public async Task<int> GetTodayCompletedCountAsync(int doctorId)
{
    using var connection = _dapperContext.CreateConnection();

    var sql = @"
        SELECT COUNT(*)
        FROM appointments
        WHERE doctor_id = @DoctorId
          AND status_id = @CompletedStatus
          AND DATE(appointment_date) = CURRENT_DATE;
    ";

    return await connection.ExecuteScalarAsync<int>(sql, new
    {
        DoctorId = doctorId,
        CompletedStatus = (int)AppointmentStatus.Completed
    });
}


        public async Task<int> GetTodayOnlineCountAsync(int doctorId)
        {
            using var connection = _dapperContext.CreateConnection();

            var sql = @"
        SELECT COUNT(*)
        FROM appointments
        WHERE doctor_id = @DoctorId
          AND mode = @OnlineMode
          AND status_id <> @RejectedStatus
          AND DATE(appointment_date) = CURRENT_DATE;
    ";

            return await connection.ExecuteScalarAsync<int>(sql, new
            {
                DoctorId = doctorId,
                OnlineMode = (int)AppointmentMode.Online,   // 1
                RejectedStatus = (int)AppointmentStatus.Rejected // 4
            });
        }


        public async Task<int> GetTodayOfflineCountAsync(int doctorId)
        {
            using var connection = _dapperContext.CreateConnection();

            var sql = @"
        SELECT COUNT(*)
        FROM appointments
        WHERE doctor_id = @DoctorId
          AND mode = @OfflineMode
          AND status_id <> @RejectedStatus
          AND DATE(appointment_date) = CURRENT_DATE;
    ";

            return await connection.ExecuteScalarAsync<int>(sql, new
            {
                DoctorId = doctorId,
                OfflineMode = (int)AppointmentMode.Offline, // 2
                RejectedStatus = (int)AppointmentStatus.Rejected
            });
        }

        public async Task<List<DoctorAppointmentListDto>> GetDoctorAppointmentsAsync(DoctorAppointmentQueryDto dto)
        {
            using var connection = _dapperContext.CreateConnection();

            var sql = @"SELECT * FROM public.fn_get_doctor_appointments(@p_doctor_id,
                       CAST(@p_appointment_date AS DATE),@p_page_size,@p_page_number,@p_sort_column,
                       @p_sort_order);";

            var result = await connection.QueryAsync<DoctorAppointmentListDto>(
                sql,
                new
                {
                    p_doctor_id = dto.DoctorId,
                    p_appointment_date = dto.AppointmentDate, 
                    p_page_size = dto.PageSize,
                    p_page_number = dto.PageNumber,
                    p_sort_column = dto.SortColumn,
                    p_sort_order = dto.SortOrder
                }
            );

            return result.ToList();
        }



    }
}
