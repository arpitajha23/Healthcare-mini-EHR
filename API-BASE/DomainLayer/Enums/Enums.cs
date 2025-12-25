using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public class Enums
    {
        public enum UserRole
        {
            Admin,
            Patient,
            Doctor
        }
        public enum Reason
        {
            Login = 1,
            ResetPassword = 2
        }
    }
}
