using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.DoctorAppointments
{
    public class DoctorAppointmentQueryDto
    {
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string SortColumn { get; set; } 
        public string SortOrder { get; set; }
    }

    public class DoctorAppointmentListDto
    {
        public int appointment_id { get; set; }

        public string patient_name { get; set; } = string.Empty;
        public string patient_email { get; set; } = string.Empty;

        public DateTime appointment_date { get; set; }
        public string appointment_time { get; set; } = string.Empty;

        public int mode { get; set; }          // 1 = Online, 2 = Offline
        public string Contact { get; set; } = string.Empty;

        public string doctor_name { get; set; } = string.Empty;
        public string reason { get; set; } = string.Empty;

        public long total_records { get; set; }
    }
}
