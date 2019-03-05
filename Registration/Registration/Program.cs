using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;

            using (File.Create("Users.txt")) ;

            List<User> usersList;
            
            using (StreamReader reader = new StreamReader("Users.txt"))
            {

                string json = reader.ReadToEnd();
                List<User> buffer = JsonConvert.DeserializeObject<List<User>>(json);

                if(buffer != null)
                {
                    usersList = buffer;
                }

                usersList = new List<User>();
            }

            while (true)
            {
                switch (Chose())
                {
                    case Constants.REGISTRATION_CHOSE:
                        Registration(usersList);
                        break;
                    case Constants.ENTRY_CHOSE:
                        if (Entry(usersList))
                        {
                            Console.WriteLine("Вы вошли");
                        }
                        else
                        {
                            Console.WriteLine("Такого аккаунта нет");
                        }
                        break;
                    case Constants.EXIT_CHOSE:
                        isRun = false;
                        break;
                }

                if (!isRun)
                {
                    break;
                }
            }
        }
        static int Chose()
        {
            try
            {
                Console.WriteLine("1. Регистрация\n" +
                                  "2. Вход\n" +
                                  "3. Выход");

                int chose;

                if (int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    if(chose == Constants.REGISTRATION_CHOSE || chose == Constants.ENTRY_CHOSE || chose == Constants.EXIT_CHOSE)
                    {
                        return chose;
                    }
                }

                throw new ArgumentException("Нету такого варианта");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return Chose();
            }
        }
        static void Registration(List<User> usersList)
        {
            User newUser = new User()
            {
                Email = SetEmail(),
                FullName = SetFullName(),
                Password = SetPassword(),
                Age = SetAge(),
                PhoneNumber = SetPhoneNumber()
            };

            if(CheckUser(newUser))
            {
                usersList.Add(newUser);
                using (StreamWriter writer = new StreamWriter("Users.txt"))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(usersList));
                }

                return;
            }

            Console.WriteLine("Такой пользователь уже есть");
        }
        static string SetEmail()
        {
            try
            {
                Console.WriteLine("Email: ");

                string email = Console.ReadLine().Trim();

                if(email == "")
                {
                    throw new ArgumentException("Email был введен неверно");
                }

                for (int i = 0; i < email.Length; i++)
                {
                    if(email[i] == ' ')
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
            catch(ArgumentException excepton)
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

                if(fullName == "")
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
            catch(ArgumentException exception)
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
            catch(ArgumentException exception)
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
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPassword();
            }
        }
        static bool CheckUser(User user)
        {
            using (StreamReader reader = new StreamReader("Users.txt"))
            {

                string json = reader.ReadToEnd();

                var users = JsonConvert.DeserializeObject<List<User>>(json);

                if (users != null)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Email == user.Email || users[i].PhoneNumber == user.PhoneNumber)
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return true;
            }
        }
        static bool Entry(List<User> usersList)
        {
            Console.WriteLine("Email:");

            string email = Console.ReadLine().Trim();

            Console.WriteLine("Password:");

            string password = Console.ReadLine().Trim();

            for(int i = 0; i < usersList.Count; i++)
            {
                if(usersList[i].Email == email && usersList[i].Password == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
