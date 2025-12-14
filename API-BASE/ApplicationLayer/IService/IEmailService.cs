using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendWelcomeEmailAsync(string to, string name);
        Task SendOtpEmailAsync(string to, string otp);
        Task SendResetPasswordEmailAsync(string to, string name, string link);
    }
}
