using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NamespacesLesson15_01_19
{
    public class User
    {
        private string _login;
        private string _password;
        private string _email;
        private string _telephoneNumber;
        
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
