using System;
using System.Linq;

namespace MagazineSubscriptions.Services
{
    public static class SetInformation
    {
        public static string SetLogin()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите логин:");

                    string login = Console.ReadLine().Trim();

                    if(login.Where(letter => (letter >= 'a' && letter <= 'z') ||
                                             (letter >= 'A' && letter <= 'Z') ||
                                             (letter >= '0' && letter <= '9') || letter == '_').ToList().Count == login.Length)
                    {
                        return login;
                    }

                    throw new ArgumentException("Неправильно ввели логин");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
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

                if(password.Where(letter => letter == ' ' || letter == '\t' || letter == '\n').ToList().Count == Constants.NULL)
                {
                    throw new ArgumentException("Password был введен неверно");
                }

                return password;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPassword();
            }
        }

        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя:");

                    string name = Console.ReadLine().Trim();

                    if(name.Where(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')).ToList().Count == name.Length)
                    {
                        return name;
                    }

                    throw new ArgumentException("Имя было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetSurname()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите фамилию:");

                    string surname = Console.ReadLine().Trim();

                    if (surname.Where(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')).ToList().Count == surname.Length)
                    {
                        return surname;
                    }

                    throw new ArgumentException("Фамилия было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetAddress()
        {
            Console.WriteLine("Введите свой адрес:");

            string address = Console.ReadLine().Trim();

            return address;
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

                if (phoneNumber.Where(letter => letter >= '0' && letter <= '9').ToList().Count != Constants.NULL)
                {
                    return phoneNumber;
                }

                throw new ArgumentException("Phone Number был введен неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPhoneNumber();
            }
        }

        public static string SetTheme()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите тему:");

                    string theme = Console.ReadLine().Trim();

                    if (theme.Where(letter => (letter >= 'a' && letter <= 'z') ||
                                              (letter >= 'A' && letter <= 'Z') || letter == ' ').ToList().Count == theme.Length)
                    {
                        return theme;
                    }

                    throw new ArgumentException("Тема была введена неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}