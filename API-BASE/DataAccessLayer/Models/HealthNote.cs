using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class HealthNote
{
    public int NoteId { get; set; }

    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public string? Diagnosis { get; set; }

    public string? Medicines { get; set; }

    public string? Recommendations { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual User Doctor { get; set; } = null!;

    public virtual User Patient { get; set; } = null!;
}
