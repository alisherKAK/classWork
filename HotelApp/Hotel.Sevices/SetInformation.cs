using HotelConstants;
using System;
using System.Linq;

namespace Hotel.Sevices
{
    public static class SetInformation
    {
        public static string SetEmail()
        {
            try
            {
                Console.WriteLine("Email: ");

                string email = Console.ReadLine().Trim();

                if (email == "" || !email.Contains('@'))
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
                Console.WriteLine(excepton.Message);

                return SetEmail();
            }
        }
        
        public static string SetLogin()
        {
            try
            {
                Console.WriteLine("Login: ");

                string login = Console.ReadLine().Trim();

                if (login == "")
                {
                    throw new ArgumentException("Full Name был введен неверно");
                }

                for (int i = 0; i < login.Length; i++)
                {
                    if (!((login[i] >= 'a' && login[i] <= 'z') || (login[i] >= 'A' && login[i] <= 'Z')) && !(login[i] >= '0' && login[i] <= '9') && login[i] != '.')
                    {
                        throw new ArgumentException("Full Name был введен неверно");
                    }
                }

                return login;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetLogin();
            }
        }
        
        public static string SetPhoneNumber()
        {
            try
            {
                Console.WriteLine("Phone Number(+7-xxx-xxx-xx-xx): ");

                string phoneNumber = Console.ReadLine().Trim();

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
                Console.WriteLine(exception.Message);

                return SetPhoneNumber();
            }
        }
        
        public static string SetPassword()
        {
            try
            {
                Console.WriteLine("Password: ");

                string password = "";

                ConsoleKeyInfo key;

                do
                {
                    key = System.Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        Console.Write("*");
                        password += key.KeyChar;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(password))
                        {
                            // remove one character from the list of password characters
                            password = password.Substring(0, password.Length - 1);
                            // get the location of the cursor
                            int pos = System.Console.CursorLeft;
                            // move the cursor to the left by one character
                            System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                            // replace it with space
                            Console.Write(" ");
                            // move the cursor to the left by one character again
                            System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                        }
                    }

                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine("");

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
                Console.WriteLine(exception.Message);

                return SetPassword();
            }
        }
    }
}