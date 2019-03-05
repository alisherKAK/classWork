using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registration
{
    public class User
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("FullName")]
        public string FullName { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        public static bool operator==(User user1, User user2)
        {
            if(user1.Email == user2.Email || user1.PhoneNumber == user2.PhoneNumber)
            {
                return true;
            }

            return false;
        }
        public static bool operator!=(User user1, User user2)
        {
            return !(user1 == user2);
        }
    }
}
