using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SomeLib
{
    public class User
    {
        private string _login;
        private string _password;
        private string _email;
        private string _telephoneNumber;
        private bool _isRegistred;

        public void Registration()
        {
            string repeatPassword;
            bool isLoginCorrect = false, isPasswordCorrect = false, isRepeatPasswordCorrect = false, isEmailCorrect = false, isTelephoneCorrect = false;

            Console.Write("Login: ");
            _login = Console.ReadLine();
            _login.Trim();

            Console.Write("Password: ");
            _password = Console.ReadLine();
            _password.Trim();

            Console.Write("Password: ");
            repeatPassword = Console.ReadLine();
            repeatPassword.Trim();

            Console.Write("Email: ");
            _email = Console.ReadLine();
            _email.Trim();

            Console.Write("Telephone number: ");
            _telephoneNumber = Console.ReadLine();
            _telephoneNumber.Trim();

            if(!_login.Equals(' '))
            {
                isLoginCorrect = true;
            }

            for(int i = 0; i < _password.Length; i++)
            {
                if ( ( (_password[i] >= 'A' && _password[i] <= 'Z' ) || (_password[i] >= (char)ConsoleKey.D0 && _password[i] <= (char)ConsoleKey.D9) || 
                    (_password[i] >= 'a' && _password[i] <= 'z') || (_password[i] == '*') ) && _password.Length >= Constants.MINIMAL_PASSWORD_LENTH)
                {
                    isPasswordCorrect = true;
                }
                else
                {
                    isPasswordCorrect = false;
                    break;
                }
            }

            if(_password == repeatPassword)
            {
                isRepeatPasswordCorrect = true;
            }

            if (_email.Contains("@") && _email.Contains(".") && (!_email.Contains(' ')))
            {
                isEmailCorrect = true;
            }

            if(isLoginCorrect && isPasswordCorrect && isRepeatPasswordCorrect && isEmailCorrect && isTelephoneCorrect)
            {
                _isRegistred = true;
            }
        }
    }
}
