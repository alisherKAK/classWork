using ExamWork.ConstantsAndEnums;
using ExamWork.DataAccess;
using ExamWork.Models;
using ExamWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbReposotiry = new DbRepository())
            {
                dbReposotiry.UpdateDatabase();
            }
            Console.Clear();

            do
            {
                Console.WriteLine("Чтобы выйти из программы нажмите на ESC, чтобы продолжить на любую клавишу");
                switch (Menu.ChoseModelMenu())
                {
                    case ConstantsAndEnums.Models.Country:
                        switch (Menu.ChoseActionsWithModelMenu())
                        {
                            case ActionsWithModel.Add:
                                ModelServices.AddCountry();
                                break;
                            case ActionsWithModel.Delete:
                                ModelServices.DeleteCountry();
                                break;
                            case ActionsWithModel.Update:
                                switch (SetInformations.SetCountryProperty())
                                {
                                    case CountryProperties.Name:
                                        ModelServices.UpdateCountry(SetInformations.SetCountryId(), CountryProperties.Name);
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого поля");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Нет такого действия");
                                break;
                        }
                        break;
                    case ConstantsAndEnums.Models.City:
                        switch (Menu.ChoseActionsWithModelMenu())
                        {
                            case ActionsWithModel.Add:
                                ModelServices.AddCity();
                                break;
                            case ActionsWithModel.Delete:
                                ModelServices.DeleteCity();
                                break;
                            case ActionsWithModel.Update:
                                switch (SetInformations.SetCityProperty())
                                {
                                    case CityProperties.Name:
                                        ModelServices.UpdateCity(SetInformations.SetCityId(), CityProperties.Name);
                                        break;
                                    case CityProperties.Population:
                                        ModelServices.UpdateCity(SetInformations.SetCityId(), CityProperties.Population);
                                        break;
                                    case CityProperties.CountryId:
                                        ModelServices.UpdateCity(SetInformations.SetCityId(), CityProperties.CountryId);
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого поля");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Нет такого действия");
                                break;
                        }
                        break;
                    case ConstantsAndEnums.Models.Street:
                        switch (Menu.ChoseActionsWithModelMenu())
                        {
                            case ActionsWithModel.Add:
                                ModelServices.AddStreet();
                                break;
                            case ActionsWithModel.Delete:
                                ModelServices.DeleteStreet();
                                break;
                            case ActionsWithModel.Update:
                                switch (SetInformations.SetStreetProperty())
                                {
                                    case StreetProperties.Name:
                                        ModelServices.UpdateStreet(SetInformations.SetStreetId(), StreetProperties.Name);
                                        break;
                                    case StreetProperties.CityId:
                                        ModelServices.UpdateStreet(SetInformations.SetStreetId(), StreetProperties.CityId);
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого поля");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Нет такого действия");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Нет такого объекта");
                        break;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
