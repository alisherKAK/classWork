using MagazineSubscriptions.DataAccess;
using MagazineSubscriptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscriptions.Services
{
    public static class Menu
    {
        public static UserAction UserMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Вход\n" +
                                      "2) Регистрация\n" +
                                      "3) Выход");

                    int chose;

                    if(int.TryParse(Console.ReadLine().Trim(), out chose))
                    {
                        return (UserAction)chose;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static void RegistrationMenu()
        {
            Console.WriteLine("===========\n" +
                              "РЕГИСТРАЦИЯ\n" +
                              "===========");

            Person newPerson = new Person()
            {
                Name = SetInformation.SetName(),
                Surname = SetInformation.SetSurname(),
                Address = SetInformation.SetAddress(),
                PhoneNumber = SetInformation.SetPhoneNumber()
            };

            User newUser = new User()
            {
                Login = SetInformation.SetLogin(),
                Password = SetInformation.SetPassword(),
                Person = newPerson
            };

            using(var context = new MagazineContext())
            {
                if (!context.People.Contains(newPerson))
                {
                    if (!context.Users.Contains(newUser))
                    {
                        context.Users.Add(newUser);
                        context.SaveChanges();

                        Console.WriteLine("Зарегистрированно");
                    }
                }
            }
        }

        public static User Entry()
        {
            Console.WriteLine("====" +
                              "ВХОД\n" +
                              "====");
            Console.WriteLine("Введите логин:");
            string login = SetInformation.SetLogin();

            Console.WriteLine("Введите пароль:");
            string password = SetInformation.SetLogin();

            using(var context = new MagazineContext())
            {
                return context.Users.Where(user => user.Login == login && user.Password == password).SingleOrDefault();
            }
        }

        public static Choises ChoiseMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите что делать:\n" +
                                      "1) Подписаться на подписку\n" +
                                      "2) Отписаться от подписки");

                    int chose;

                    if(int.TryParse(Console.ReadLine().Trim(), out chose))
                    {
                        return (Choises)chose;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static SubsritionsType ChoseSubscription(User user)
        {
            do
            {
                try
                {
                    Console.WriteLine("Подписки\n" +
                                      "1) 12 месяцев - 100$\n" +
                                      "2) 24 месяцев - 200$\n" +
                                      "3) 36 месяцев - 300$");

                    int choseSubsription;

                    if(int.TryParse(Console.ReadLine().Trim(), out choseSubsription))
                    {
                        return (SubsritionsType)choseSubsription;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static AdminAction AdminMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Добавить журнал\n" +
                                      "2) Сделать отчет\n" +
                                      "3) Выход");

                    int adminChose;

                    if(int.TryParse(Console.ReadLine().Trim(), out adminChose))
                    {
                        return (AdminAction)adminChose;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static ReporstType ChoseReport()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Отчет о доходах\n" +
                                      "2) Отчет о пользователях");

                    int reportChose;

                    if(int.TryParse(Console.ReadLine().Trim(), out reportChose))
                    {
                        return (ReporstType)reportChose;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
