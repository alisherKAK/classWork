using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.ConsoleApp
{
    public static class SetInformation
    {
        public static string SetFIO()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите свое ФИО:");

                    string fio = Console.ReadLine().Trim();
                    
                    if(fio == "")
                    {
                        throw new ArgumentException("введите значение");
                    }

                    for(int i = 0; i < fio.Length; i++)
                    {
                        if((fio[i] >= '0' && fio[i] <= '9') || fio[i] == ' ' || fio[i] == '$' || fio[i] == '?' || fio[i] == '.' || fio[i] == '!' || fio[i] == '_'
                            || fio[i] == '/' || fio[i] == '*' || fio[i] == '+' || fio[i] == '-' || fio[i] == '\n' || fio[i] == '\t')
                        {
                            throw new ArgumentException("ФИО был введен неверно");
                        }
                    }

                    return fio;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static int SetGender()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Male\n" +
                                      "2) Female");

                    int chose;

                    if (int.TryParse(Console.ReadLine().Trim(), out chose))
                    {
                        switch (chose)
                        {
                            case (int)Genders.Male:
                                return (int)Genders.Male;
                            case (int)Genders.Female:
                                return (int)Genders.Female;
                            default:
                                throw new ArgumentException("Нету такого пола");
                        }
                    }

                    throw new ArgumentException("Значение было введено неверно ");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
