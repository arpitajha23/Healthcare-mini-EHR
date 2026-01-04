using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class OtpHistory
    {
        public long OtpId { get; set; }

        public int UserId { get; set; }

        public string OtpCode { get; set; }

        public int OtpTypeId { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsVerified { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }

}
