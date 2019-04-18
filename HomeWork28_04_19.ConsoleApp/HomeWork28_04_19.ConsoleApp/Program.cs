using HomeWork28_04_19.DataAccess;
using HomeWork28_04_19.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28_04_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;

            do
            {
                switch (ChoicesMenu.ChoseWhatToDo())
                {
                    case Constants.ENTER_CHOICE:
                        RecordsService.CraeteReacord();
                        break;
                    case Constants.EXIT_CHOICE:
                        RecordsService.FinishRecord();
                        break;
                    case Constants.PROGRAMM_FINISH_CHOICE:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Выберите существующи вариант");
                        break;
                }
            } while (!isFinish);
        }
    }
}
