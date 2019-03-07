using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HomeWork17_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Type type = typeof(Console);

            var methods = type.GetMethods();

            Console.WriteLine("Console's methods:");
            Console.WriteLine("==================");

            foreach (MethodInfo method in methods)
            {
                var parametrs = method.GetParameters();
                string paramsView = "";

                foreach (ParameterInfo parametr in parametrs)
                {
                    paramsView += $"{parametr.ParameterType.Name} {parametr.Name}, ";
                }

                paramsView = paramsView.Trim(' ').Trim(',');

                Console.WriteLine($"{method.Name}({paramsView})");
            }
            Console.WriteLine("========================================");

            //2
            User newUser = new User
            {
                FullName = SetFullName(),
                Age = SetAge(),
                Email = SetEmail(),
                Password = SetPassword(), 
                PhoneNumber = SetPhoneNumber()
            };

            Console.WriteLine("========================================");

            Type userType = typeof(User);

            var properties = userType.GetProperties();

            foreach(var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(newUser)}");
            }
        }
        static string SetEmail()
        {
            try
            {
                Console.WriteLine("Email: ");

                string email = Console.ReadLine().Trim();

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
                Console.WriteLine(excepton.Message);

                return SetEmail();
            }
        }
        static string SetFullName()
        {
            try
            {
                Console.WriteLine("Full Name: ");

                string fullName = Console.ReadLine().Trim();

                if (fullName == "")
                {
                    throw new ArgumentException("Full Name был введен неверно");
                }

                for (int i = 0; i < fullName.Length; i++)
                {
                    if (!((fullName[i] >= 'a' && fullName[i] <= 'z') || (fullName[i] >= 'A' && fullName[i] <= 'Z')))
                    {
                        throw new ArgumentException("Full Name был введен неверно");
                    }
                }

                return fullName;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetFullName();
            }
        }
        static int SetAge()
        {
            try
            {
                int age;

                Console.WriteLine("Age: ");

                if (int.TryParse(Console.ReadLine().Trim(), out age))
                {
                    return age;
                }

                throw new ArgumentException("Age был введен неверено");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetAge();
            }
        }
        static string SetPhoneNumber()
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
        static string SetPassword()
        {
            try
            {
                Console.WriteLine("Password: ");

                string password = "";

                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);
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
                            int pos = Console.CursorLeft;
                            // move the cursor to the left by one character
                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            // replace it with space
                            Console.Write(" ");
                            // move the cursor to the left by one character again
                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        }
                    }

                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine();

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
