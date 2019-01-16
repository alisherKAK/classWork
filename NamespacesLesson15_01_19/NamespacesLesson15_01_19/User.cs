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
        private bool _isRegistred;

        public void Registration()
        {
            string repeatPassword;

            while (true)
            {
                Console.Write("Login: ");
                _login = Console.ReadLine();
                _login.Trim();

                Console.Write("Password: ");
                _password = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Console.Write("*");
                        _password += key.KeyChar;
                    }
                } while (key.Key != ConsoleKey.Enter);
                _password.Trim();
                Console.WriteLine();

                Console.Write("Repeat password: ");
                repeatPassword = Console.ReadLine();
                repeatPassword.Trim();

                Console.Write("Email: ");
                _email = Console.ReadLine();
                _email.Trim();

                Console.Write("Telephone number (+r-xxx-xxx-xx-xx): ");
                _telephoneNumber = Console.ReadLine();
                _telephoneNumber.Trim();

                if (_login.Contains(" "))
                {
                    throw new ArgumentException("Ошибка! Логин введен не верно!");
                }

                for (int i = 0; i < _password.Length; i++)
                {
                    if (_password[i] < 'A' && _password[i] > 'Z')
                    {
                        if(_password[i] < 'a' && _password[i] > 'z')
                        {
                            if(_password[i] < (char)ConsoleKey.D0 && _password[i] > (char)ConsoleKey.D9)
                            {
                                if(_password[i] != '$')
                                {
                                     throw new ArgumentException("Ошибка! Пароль не соответствует требованиям!");
                                }
                            }
                        }
                    }
                }

                if (_password != repeatPassword)
                {
                    throw new ArgumentException("Ошибка! Пароль не соответствует!");
                }

                if (_email.Split('@')[Constants.SECOND_PART].Split('.').Length != Constants.EMAIL_CHECK_NUMEBR)
                {
                    throw new ArgumentException("Ошибка! Неверный email!");
                }

                int secretNumbers = Constants.NULL;
                Random randNumber = new Random();
                for (int i = 0; i < Constants.SECRET_NUMBERS_COUNT; i++)
                {
                    secretNumbers *= Constants.ADD_ONE_ZERO;
                    secretNumbers += randNumber.Next(Constants.NULL, Constants.NINE);
                }

                SMS.GetSms(_telephoneNumber, secretNumbers.ToString());
                Console.Write("Secret code: ");

                if (Console.ReadLine() == secretNumbers.ToString())
                {
                    _isRegistred = true;
                    Console.WriteLine($"{_login} Registred!");
                    break;
                }
                else
                {
                    _isRegistred = false;
                    throw new ArgumentException("Код был введен неверно!");
                }
            }
        }
    }
}
