using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28_04_19.Services
{
    public static class ChoicesMenu
    {
        public static int ChoseWhatToDo()
        {
            do
            {
                try
                {
                    Console.WriteLine("Чтобы записать нового пользователя нажмите на '1'\n" +
                                      "Чтобы записать время ухода человека нажмите на '2'\n" +
                                      "Чтобы выйти из программы нажмите на '3'");

                    int choice;

                    if(int.TryParse(Console.ReadLine().Trim(), out choice))
                    {
                        return choice;
                    }

                    throw new ArgumentException("Введите число правильно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
