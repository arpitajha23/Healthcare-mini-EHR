using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CommonMethod
{
    public class MaskHelpers
    {
        // Mask the Email
        public static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return email;

            var parts = email.Split('@');
            var namePart = parts[0];
            var domainPart = parts[1];

            var visibleChars = Math.Min(3, namePart.Length);
            var prefix = namePart.Substring(0, visibleChars);
            var masked = prefix + "***";

            return $"{masked}@{domainPart}";
        }

        //Mask the Phone Number
        public static string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length <= 4)
                return phone;

            var last4 = phone.Substring(phone.Length - 4);
            var maskedPart = new string('*', phone.Length - 4);
            return maskedPart + last4;
        }
    }
}
