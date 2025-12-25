using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Enums.Enums;

namespace DomainLayer.CommonMethod
{
    public class EmailTemplates
    {
        public (string Subject, string Body) WelcomeTemplate(string name)
        {
            string subject = "🎉 Welcome to Healthcare Portal";

            string body = $@"
    <div style='font-family: Arial, Helvetica, sans-serif; background-color:#f4f6f8; padding:20px;'>
        <div style='max-width:600px; margin:auto; background:#ffffff; border-radius:8px; overflow:hidden;'>
            
            <!-- Header -->
            <div style='background:#4c87b9; padding:20px; text-align:center;'>
                <h1 style='color:#ffffff; margin:0;'>Healthcare Portal</h1>
            </div>

            <!-- Body -->
            <div style='padding:25px; color:#333;'>
                <h2 style='color:#4c87b9;'>Hello {name},</h2>

                <p style='font-size:15px; line-height:1.6;'>
                    Welcome to <strong>Healthcare Portal</strong>!  
                    Your registration has been successfully completed.
                </p>

                <p style='font-size:15px; line-height:1.6;'>
                    You can now access your dashboard, manage appointments, and stay connected with your healthcare services.
                </p>

                <div style='margin:30px 0; text-align:center;'>
                    <span style='display:inline-block; background:#4c87b9; color:#ffffff; padding:12px 20px; border-radius:25px; font-size:14px;'>
                        We’re glad to have you!
                    </span>
                </div>

                <p style='font-size:14px; color:#555;'>
                    Thanks & regards,<br/>
                    <strong>Healthcare Team</strong>
                </p>
            </div>

            <!-- Footer -->
            <div style='background:#f0f0f0; padding:15px; text-align:center; font-size:12px; color:#777;'>
                © {DateTime.UtcNow.Year} Healthcare Portal. All rights reserved.
            </div>

        </div>
    </div>";

            return (subject, body);
        }


        public (string Subject, string Body) OtpTemplate(string otp, string fullName, Reason reason)
        {
            string subject = $"🔐 {reason} OTP Verification Code";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
</head>
<body style='margin:0; padding:0; background-color:#eef2f7;'>

<table width='100%' cellpadding='0' cellspacing='0' style='background-color:#eef2f7; padding:30px 0;'>
<tr>
<td align='center'>

<table width='600' cellpadding='0' cellspacing='0' style='background:#ffffff; border-radius:12px; box-shadow:0 8px 25px rgba(0,0,0,0.08); overflow:hidden;'>

    <!-- Header -->
    <tr>
        <td style='background:linear-gradient(135deg, #4c87b9, #6fa8dc); padding:25px; text-align:center;'>
            <h1 style='margin:0; color:#ffffff; font-family:Arial, sans-serif; font-size:24px;'>
                OTP Verification
            </h1>
        </td>
    </tr>

    <!-- Content -->
    <tr>
        <td style='padding:30px; font-family:Arial, Helvetica, sans-serif; color:#333;'>

            <p style='font-size:16px;'>Hello <strong>{fullName}</strong>,</p>

            <p style='font-size:15px; line-height:1.6;'>
                You requested an OTP for <strong>{reason}</strong>.
                Please use the code below to continue.
            </p>

            <!-- OTP Box -->
            <div style='text-align:center; margin:30px 0;'>
                <span style='
                    display:inline-block;
                    background:#f0f7ff;
                    color:#2c5aa0;
                    font-size:28px;
                    letter-spacing:6px;
                    font-weight:bold;
                    padding:15px 30px;
                    border-radius:8px;
                    border:2px dashed #4c87b9;'>
                    {otp}
                </span>
            </div>

            <p style='font-size:14px; color:#555; text-align:center;'>
                ⏱ This OTP is valid for a limited time.
            </p>

            <p style='font-size:14px; color:#777; text-align:center;'>
                🔒 For your security, do not share this code with anyone.
            </p>

        </td>
    </tr>

    <!-- Footer -->
    <tr>
        <td style='background:#f7f9fc; padding:18px; text-align:center; font-family:Arial, sans-serif; font-size:13px; color:#888;'>
            If you did not request this OTP, please ignore this email.<br/>
            <strong>HealthcareFriend</strong>
        </td>
    </tr>

</table>

</td>
</tr>
</table>

</body>
</html>";

            return (subject, body);
        }


        public (string Subject, string Body) ResetPasswordTemplate(string name, string link)
        {
            string subject = "🔑 Password Reset Instructions";

            string body = $@"
    <div style='font-family: Arial, Helvetica, sans-serif; background-color:#f4f6f8; padding:20px;'>
        <div style='max-width:600px; margin:auto; background:#ffffff; border-radius:8px; overflow:hidden;'>

            <!-- Header -->
            <div style='background:#4c87b9; padding:20px; text-align:center;'>
                <h2 style='color:#ffffff; margin:0;'>Password Reset</h2>
            </div>

            <!-- Body -->
            <div style='padding:25px; color:#333;'>
                <p style='font-size:15px;'>Hello {name},</p>

                <p style='font-size:15px; line-height:1.6;'>
                    We received a request to reset your password.
                    Click the button below to proceed.
                </p>

                <div style='text-align:center; margin:30px 0;'>
                    <a href='{link}' 
                       style='background:#4c87b9; color:#ffffff; padding:12px 24px; text-decoration:none; border-radius:25px; font-size:14px;'>
                        Reset Password
                    </a>
                </div>

                <p style='font-size:14px; color:#777;'>
                    If you did not request a password reset, you can safely ignore this email.
                </p>

                <p style='font-size:14px;'>
                    Thanks,<br/>
                    <strong>Healthcare Team</strong>
                </p>
            </div>

        </div>
    </div>";

            return (subject, body);
        }

    }
}
