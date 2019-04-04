using Hotel.DataAccess;
using Hotel.Models;
using Hotel.Sevices;
using System;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Registration();

            //Console.ReadLine();
            using (TableDataService<User> tableDataService = new TableDataService<User>())
            {
                User user = new User()
                {
                    Id = 1,
                    Login = "jhvijfvr",
                    Password = "vhbfihnj",
                    Email = "uhviufh@hvfi.vjir",
                    Phone = "+77071231101"
                };

                tableDataService.DeleteById(1);
            }
        }
        static int Chose()
        {
            try
            {
                Console.WriteLine("1) Вход\n" +
                                  "2) Регистрация\n" +
                                  "3) Выход");

                int chose;

                if(int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    return chose;
                }

                throw new ArgumentException("Выбор сделан неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return Chose();
            }
        }
        static User Registration()
        {
            User user = new User
            {
                Login = SetInformation.SetLogin(),
                Password = SetInformation.SetPassword(),
                Email = SetInformation.SetEmail(),
                Phone = SetInformation.SetPhoneNumber()
            };


            TelegramBot telegramBot = new TelegramBot();
            telegramBot.Open();
            telegramBot.Send("Напишите боту 'Get code' чтобы плучить код");
            CheckCode();
            telegramBot.Close();
            return user;
        }
        static void CheckCode()
        {
            try
            {
                Console.WriteLine("Введите полученный код: ");
                if(Console.ReadLine().Trim() == CodeGenerator.Code)
                {
                    return;
                }

                throw new ArgumentException("Неверный код ");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                CheckCode();
            }
        }
        static bool IsUserHave(User newUser)
        {
            using (TableDataService<User> tableService = new TableDataService<User>())
            {
                var data = tableService.GetAll();

                foreach (User user in data)
                {
                    if (user.Login == newUser.Login || user.Email == newUser.Email || user.Phone == newUser.Phone)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
