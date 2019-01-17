using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespacesLesson15_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            string repeatPassword;
            bool firstCondition = false, secondCondition = false, thirdCondition = false;
            string secretNumbers = Constants.STRING_NULL;
            ConsoleKeyInfo info;
            Random randNumber = new Random();

            //Login
            while (true)
            {
                try
                {
                    Console.Write("Login: ");
                    user.Login = Console.ReadLine();
                    user.Login = user.Login.Trim();

                    for(int i = 0; i < user.Login.Length; i++)
                    {
                        if( !((user.Login[i] >= 'A' && user.Login[i] <= 'Z') || (user.Login[i] >= 'a' && user.Login[i] <= 'z') || 
                              (user.Login[i] >= (char)ConsoleKey.D0 && user.Login[i] <= (char)ConsoleKey.D9)) )
                        {
                            throw new ArgumentException("Ошибка! Логин введен не верно!");
                        }
                    }

                    if (user.Login.Contains(" ") || user.Login == "")
                    {
                        throw new ArgumentException("Ошибка! Логин введен не верно!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            //Password
            while (true)
            {
                try
                {
                    Console.Write("Password: ");
                    user.Password = "";

                    while (true)
                    {
                        info = Console.ReadKey(true);
                        if (info.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                        if (info.Key != ConsoleKey.Backspace)
                        {
                            Console.Write("*");
                            user.Password += info.KeyChar;
                        }
                        else if (info.Key == ConsoleKey.Backspace)
                        {
                            if (!string.IsNullOrEmpty(user.Password))
                            {
                                user.Password = user.Password.Substring(0, user.Password.Length - 1);
                                int pos = Console.CursorLeft;
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            }
                        }
                    }
                    user.Password = user.Password.Trim();

                    for (int i = 0; i < user.Password.Length; i++)
                    {
                        if (user.Password[i] >= 'A' && user.Password[i] <= 'Z')
                        {
                            firstCondition = true;
                        }
                        if (user.Password[i] >= 'a' && user.Password[i] <= 'z')
                        {
                            secondCondition = true;
                        }
                        if (user.Password[i] >= '!' && user.Password[i] <= '@')
                        {
                            thirdCondition = true;
                        }
                    }
                    if ((firstCondition && secondCondition && thirdCondition) == false)
                    {
                        throw new ArgumentException("Пароль не соответствует требованием!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            //RepeatPassword
            while (true)
            {
                try
                {
                    repeatPassword = Constants.STRING_NULL;

                    Console.Write("Repeat password: ");
                    while (true)
                    {
                        info = Console.ReadKey(true);
                        if (info.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                        if (info.Key != ConsoleKey.Backspace)
                        {
                            Console.Write("*");
                            repeatPassword += info.KeyChar;
                        }
                        else if (info.Key == ConsoleKey.Backspace)
                        {
                            if (!string.IsNullOrEmpty(user.Password))
                            {
                                user.Password = user.Password.Substring(0, user.Password.Length - 1);
                                int pos = Console.CursorLeft;
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            }
                        }
                    }
                    repeatPassword = repeatPassword.Trim();

                    if (user.Password != repeatPassword)
                    {
                        throw new ArgumentException("Ошибка! Пароль не соответствует!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            //Email
            while (true)
            {
                try
                {
                    Console.Write("Email: ");
                    user.Email = Console.ReadLine();
                    user.Email = user.Email.Trim();

                    if (user.Email.Contains("@") && user.Email.Contains("."))
                    {
                        if (user.Email.Split('@')[Constants.SECOND_PART].Split('.').Length != Constants.EMAIL_CHECK_NUMEBR)
                        {
                            throw new ArgumentException("Ошибка! Неверный email!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Ошибка! Неверный email!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            //PhoneNumber
            while (true)
            {
                try
                {
                    Console.Write("Telephone number (+r-xxx-xxx-xx-xx): ");
                    user.TelephoneNumber = Console.ReadLine();
                    user.TelephoneNumber = user.TelephoneNumber.Trim();

                    if (user.TelephoneNumber != "")
                    {
                        if (user.TelephoneNumber[Constants.ARRAY_START] == '+' && user.TelephoneNumber.Length == Constants.STANDART_COUNT_SYBOLS_IN_PHONE_NUMBER)
                        {
                            for (int i = 1; i < user.TelephoneNumber.Length; i++)
                            {
                                if (!(user.TelephoneNumber[i] >= (char)ConsoleKey.D0 && user.TelephoneNumber[i] <= (char)ConsoleKey.D9))
                                {
                                    throw new ArgumentException("Неверно был введен номер телефона!");
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Неверно был введен номер телефона!");
                        }

                    }
                    else
                    {
                        throw new ArgumentException("Неверно был введен номер телефона!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            string secretCode;

            for (int i = 0; i < Constants.SECRET_NUMBERS_COUNT; i++)
            {
                secretNumbers += randNumber.Next(Constants.NULL, Constants.NINE).ToString();
            }

            SmsSenderService.GetSms(user.TelephoneNumber, secretNumbers);

            //SecretCode
            while (true)
            {
                try
                {
                    Console.Write("Secret code: ");

                    secretCode = Console.ReadLine();

                    if (secretCode.Length == Constants.STANDART_COUNT_NUMBER_IN_SECRED_CODE)
                    {
                        for (int i = 0; i < secretCode.Length; i++)
                        {
                            if (!(secretCode[i] >= '0' && secretCode[i] <= '9'))
                            {
                                throw new ArgumentException("Код был введен неверно!");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Код был введен неверно!");
                    }

                    if (secretCode == secretNumbers)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{user.Login} Registred!");
                    }
                    else
                    {
                        throw new ArgumentException("Код был введен неверно!");
                    }

                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
