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


        public (string Subject, string Body) OtpTemplate(string otp)
        {
            string subject = "🔐 Your OTP Code";

            string body = $@"
    <div style='font-family: Arial, Helvetica, sans-serif; background-color:#f4f6f8; padding:20px;'>
        <div style='max-width:600px; margin:auto; background:#ffffff; border-radius:8px; padding:25px;'>

            <h2 style='color:#4c87b9; text-align:center;'>OTP Verification</h2>

            <p style='font-size:15px; color:#333; text-align:center;'>
                Use the following One-Time Password to continue:
            </p>

            <div style='text-align:center; margin:25px 0;'>
                <span style='font-size:24px; letter-spacing:4px; font-weight:bold; background:#f0f7ff; padding:12px 20px; border-radius:6px; display:inline-block;'>
                    {otp}
                </span>
            </div>

            <p style='font-size:14px; color:#777; text-align:center;'>
                Do not share this code with anyone.  
                This OTP is valid for a limited time.
            </p>

        </div>
    </div>";

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
