using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

public partial class User
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("phone")]
    public string Phone { get; set; } 

    [Column("dob")]
    public DateOnly? Dob { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("role")]
    public string Role { get; set; }

    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("is_locked")]
    public bool? IsLocked { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("password_modified_at")]
    public DateTime? PasswordModifiedAt { get; set; }

    public virtual ICollection<Appointment> AppointmentDoctors { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentPatients { get; set; } = new List<Appointment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<HealthNote> HealthNoteDoctors { get; set; } = new List<HealthNote>();

    public virtual ICollection<HealthNote> HealthNotePatients { get; set; } = new List<HealthNote>();
}
