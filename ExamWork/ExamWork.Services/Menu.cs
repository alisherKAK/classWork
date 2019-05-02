using ExamWork.ConstantsAndEnums;
using System;

namespace ExamWork.Services
{
    public static class Menu
    {
        public static ExamWork.ConstantsAndEnums.Models ChoseModelMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите что хотите добавить, удалить или изменить:\n" +
                                      "1) Страна\n" +
                                      "2) Город\n" +
                                      "3) Улица");

                    int model;

                    if(int.TryParse(Console.ReadLine().Trim(), out model))
                    {
                        return (ConstantsAndEnums.Models)model;
                    }

                    throw new ArgumentException("Число было введено неверено");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static ActionsWithModel ChoseActionsWithModelMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите что хотите сделать:\n" +
                                      "1) Добавить\n" +
                                      "2) Удалить\n" +
                                      "3) Изменить");

                    int actionWithModel;

                    if(int.TryParse(Console.ReadLine().Trim(), out actionWithModel))
                    {
                        return (ActionsWithModel)actionWithModel;
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
