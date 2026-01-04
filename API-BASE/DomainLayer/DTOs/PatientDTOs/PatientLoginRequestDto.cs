using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.PatientDTOs
{
    public class PatientLoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }
    }
    public class VerifyOtpRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Otp { get; set; }
    }

    public class ResendOtpRequest
    {
        public int UserId { get; set; }
    }

}
