using ApplicationLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs;
using Microsoft.Extensions.Options;
using DomainLayer.CommonMethod;
using static DomainLayer.Enums.Enums;

namespace ApplicationLayer.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly EmailTemplates _template;


        public EmailService(IOptions<EmailSettings> settings, EmailTemplates emailTemplates)
        {
            _settings = settings.Value;
            _template = emailTemplates;
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            using var smtp = new SmtpClient
            {
                Host = _settings.Host,
                Port = _settings.Port,
                EnableSsl = _settings.EnableSSL,
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_settings.UserName, _settings.DisplayName),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };

            mail.To.Add(to);

            await smtp.SendMailAsync(mail);
        }

        public async Task SendWelcomeEmailAsync(string to, string name)
        {
            var (subject, body) = _template.WelcomeTemplate(name);
            await SendEmailAsync(to, subject, body);
        }

        public async Task SendOtpEmailAsync(string to, string otp, string fullName)
        {
            var (subject, body) = _template.OtpTemplate(otp, fullName, Reason.Login);
            await SendEmailAsync(to, subject, body);
        }

        public async Task SendResetPasswordEmailAsync(string to, string name, string link)
        {
            var (subject, body) = _template.ResetPasswordTemplate(name, link);
            await SendEmailAsync(to, subject, body);
        }
    }
}
