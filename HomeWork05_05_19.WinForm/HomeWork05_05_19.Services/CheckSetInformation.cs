using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork05_05_19.Services
{
    public static class CheckSetInformation
    {
        public static bool CheckCityPhoneNumber(string cityPhoneNumber)
        {
            if (cityPhoneNumber.Where(number => (number >= '0' && number <= '9')).ToList().Count == Constants.CITY_PHONE_NUMBER_LENGTH)
            {
                return true;
            }

            return false;
        }

        public static bool CheckUsername(string username)
        {
            if(username.Where(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')).ToList().Count == username.Length)
            {
                return true;
            }

            return false;
        }
    }
}
