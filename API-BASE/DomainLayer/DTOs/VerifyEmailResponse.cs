using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    public class VerifyEmailResponse
    {
        public bool IsAvailable { get; set; }
        public string? Email { get; set; }
        public int Role { get; set; }
    }

    public class VerifyEmailRequest
    {
        public string Email { get; set; } = string.Empty;
    }
}
