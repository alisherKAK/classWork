using Hotel.Services.Abstract;
using HotelConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Sevices
{
    public class SetInformation
    {
        private readonly IReporter reporter;
        private readonly IReader reader;

        public SetInformation(IReporter reporter, IReader reader)
        {
            this.reporter = reporter;
            this.reader = reader;
        }

        public string SetEmail()
        {
            try
            {
                reporter.Send("Email: ");

                string email = reader.Read();

                if (email == "")
                {
                    throw new ArgumentException("Email был введен неверно");
                }

                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == ' ')
                    {
                        throw new ArgumentException("Email был введен неверно");
                    }
                }

                if (email.Split('@')[Constants.SECOND_ELEMENT].Split('.').Length == Constants.CHECK_EMAIL_NUMBER && email.Split('@')[Constants.FIRST_ELEMENT] != "")
                {
                    return email;
                }

                throw new ArgumentException("Email был введен неверно");
            }
            catch (ArgumentException excepton)
            {
                reporter.Send(excepton.Message);

                return SetEmail();
            }
        }
        
        public string SetLogin()
        {
            try
            {
                reporter.Send("Login: ");

                string login = reader.Read();

                if (login == "")
                {
                    throw new ArgumentException("Full Name был введен неверно");
                }

                for (int i = 0; i < login.Length; i++)
                {
                    if (!((login[i] >= 'a' && login[i] <= 'z') || (login[i] >= 'A' && login[i] <= 'Z')) || !(login[i] >= '0' && login[i] <= '9') || login[i] != '.')
                    {
                        throw new ArgumentException("Full Name был введен неверно");
                    }
                }

                return login;
            }
            catch (ArgumentException exception)
            {
                reporter.Send(exception.Message);

                return SetLogin();
            }
        }
        
        public string SetPhoneNumber()
        {
            try
            {
                reporter.Send("Phone Number(+7-xxx-xxx-xx-xx): ");

                string phoneNumber = reader.Read();

                if (phoneNumber.Length != Constants.PHONE_LENGTH)
                {
                    throw new ArgumentException("Phone Number был введен неверно");
                }

                if (phoneNumber[Constants.SECOND_ELEMENT] != Constants.PHONE_FIRST_NUMBER)
                {
                    throw new ArgumentException("Phone Number был введен неверно");
                }

                for (int i = Constants.SECOND_ELEMENT; i < phoneNumber.Length; i++)
                {
                    if (!(phoneNumber[i] >= '0' && phoneNumber[i] <= '9'))
                    {
                        throw new ArgumentException("Phone Number был введен неверно");
                    }
                }

                return phoneNumber;
            }
            catch (ArgumentException exception)
            {
                reporter.Send(exception.Message);

                return SetPhoneNumber();
            }
        }
        
        public string SetPassword()
        {
            try
            {
                reporter.Send("Password: ");

                string password = "";

                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        reporter.Send("*");
                        password += key.KeyChar;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(password))
                        {
                            // remove one character from the list of password characters
                            password = password.Substring(0, password.Length - 1);
                            // get the location of the cursor
                            int pos = Console.CursorLeft;
                            // move the cursor to the left by one character
                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            // replace it with space
                            reporter.Send(" ");
                            // move the cursor to the left by one character again
                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        }
                    }

                } while (key.Key != ConsoleKey.Enter);

                reporter.Send("");

                password = password.Trim();

                if (password.Length < Constants.PASSWORD_MINIMAL_LENGTH)
                {
                    throw new ArgumentException("Password был введен неверно");
                }

                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == ' ' || password[i] == '\t' || password[i] == '\n')
                    {
                        throw new ArgumentException("Password был введен неверно");
                    }
                }

                return password;
            }
            catch (ArgumentException exception)
            {
                reporter.Send(exception.Message);

                return SetPassword();
            }
        }
    }
}