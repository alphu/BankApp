using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMS.Application
{
    public static class Validator
    {
        public static bool IsValidEmail(string emailId)
        {
            bool isValid = Regex.IsMatch(emailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isValid;
        }

        public static bool IsValidPan(string panId)
        {
            bool isValid = Regex.IsMatch(panId, @"([A-Z]){5}([0-9]){4}([A-Z]){1}$", RegexOptions.IgnoreCase);
            return isValid;
        }

        public static bool IsValidMobileNumber(string mobNumber)
        {
            bool isValid = Regex.IsMatch(mobNumber, @"^[6-9]\d{9}$", RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}
