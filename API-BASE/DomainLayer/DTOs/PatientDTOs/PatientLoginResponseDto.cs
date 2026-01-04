using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.PatientDTOs
{
    public class PatientLoginResponseDto
    {
        public string Token { get; set; }
        public string MaskedEmail { get; set; }
        public string MaskedPhone { get; set; }
        public int Role { get; set; }
    }
}
