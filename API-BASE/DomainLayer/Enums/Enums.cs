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
            Admin = 1,
            Patient =3,
            Doctor =2
        }
     

        public enum Reason
        {
            Login = 1,
            ResetPassword = 2
        }

        public enum OtpType
        {
            Login = 1,
            PasswordReset = 2,
            EmailVerification = 3,
            PhoneVerification = 4
        }

        /// <summary>
        /// Appointment
        /// </summary>
        public enum AppointmentMode
        {
            Online = 1,
            Offline = 2
        }

        public enum AppointmentStatus
        {
            Pending = 1,
            Approved = 2,
            Completed = 3,
            Rejected = 4
        }


    }
}
