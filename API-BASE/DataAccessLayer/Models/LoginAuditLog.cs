using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class LoginAuditLog
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int? RoleId { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; }
    }
}
