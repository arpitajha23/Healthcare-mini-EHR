using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public string Role { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsLocked { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? PasswordModifiedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Appointment> AppointmentDoctors { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentPatients { get; set; } = new List<Appointment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<HealthNote> HealthNoteDoctors { get; set; } = new List<HealthNote>();

    public virtual ICollection<HealthNote> HealthNotePatients { get; set; } = new List<HealthNote>();
}
