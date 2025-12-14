using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Doctor { get; set; } = null!;

    public virtual ICollection<HealthNote> HealthNotes { get; set; } = new List<HealthNote>();

    public virtual User Patient { get; set; } = null!;
}
