using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26_04_19.Services
{
    public static class ChoicesMenu
    {
        public static Columns ChoseColumn()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите поле которое хотите изменить:" +
                                      "1) Name\n" +
                                      "2) Price\n" +
                                      "3) Amount\n" +
                                      "4) Production Date\n" +
                                      "5) Expiration Date\n" +
                                      "6) ProducerId");

                    int column;

                    if(int.TryParse(Console.ReadLine().Trim(), out column) && column >= 1 && column <= 6)
                    {
                        return (Columns)column;
                    }

                    throw new ArgumentException("Нету такого поля");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static Operations ChoseOperation()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите операцию которую хотите совершить с данными:" +
                                      "1) Add\n" +
                                      "2) Remove\n" +
                                      "3) Edit");

                    int operation;

                    if(int.TryParse(Console.ReadLine().Trim(), out operation) && operation >= 1 && operation <= 3)
                    {
                        return (Operations)operation;
                    }

                    throw new ArgumentException("Нет такой операций");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static void ChoseWhoWillBeRemoved()
        {
            do
            {
                try
                {
                }
                catch (Exception)
                {

                    throw;
                }
            } while (true);
        }
    }
}
