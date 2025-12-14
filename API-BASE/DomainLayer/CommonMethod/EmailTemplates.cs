using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CommonMethod
{
    public class EmailTemplates
    {
        public (string Subject, string Body) WelcomeTemplate(string name)
        {
            string subject = "Welcome to Healthcare Portal";
            string body = $@"
                <h2>Hello {name},</h2>
                <p>Welcome to our Healthcare Portal. Your registration is now complete!</p>
                <p>Thanks,<br/>Healthcare Team</p>";

            return (subject, body);
        }

        public (string Subject, string Body) OtpTemplate(string otp)
        {
            string subject = "Your OTP Code";
            string body = $@"
                <h2>Your OTP Verification</h2>
                <p>Your OTP is <strong>{otp}</strong>. Do not share this code.</p>";

            return (subject, body);
        }
        public (string Subject, string Body) ResetPasswordTemplate(string name, string link)
        {
            string subject = "Password Reset Instructions";
            string body = $@"
                <h2>Hello {name},</h2>
                <p>We received a request to reset your password.</p>
                <p><a href='{link}'>Click here to reset your password</a>.</p>
                <p>If you did not request this, please ignore this message.</p>";

            return (subject, body);
        }
    }
}
