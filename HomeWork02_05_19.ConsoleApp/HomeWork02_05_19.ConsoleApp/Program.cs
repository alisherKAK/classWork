using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using HomeWork02_05_19.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02_05_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;

            do
            {
                switch (Menu.ActionMenu())
                {
                    case Actions.Add:
                        switch (Menu.AddMenu())
                        {
                            case Services.Models.Band:
                                ModelCreator.CreateAndSaveBand();
                                break;
                            case Services.Models.Music:
                                do
                                {
                                    try
                                    {
                                        var musicsBand = SelectInformation.SelectBandByIndex(Menu.BandSelectMenu());
                                        ModelCreator.CreateAndSaveMusic(musicsBand.Id);
                                        break;
                                    }
                                    catch(ArgumentOutOfRangeException)
                                    {
                                        Console.WriteLine("Добвление новой группы:");
                                        ModelCreator.CreateAndSaveBand();
                                    }
                                    catch(IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("Такая группа уже существует");
                                    }
                                } while (true);
                                break;
                            default:
                                Console.WriteLine("Нет такого объекта");
                                break;
                        }
                        break;
                    case Actions.View:
                        switch (Menu.WhatShow())
                        {
                            case Services.Models.Band:
                                Menu.ShowAllBands();
                                break;
                            case Services.Models.Music:
                                switch (Menu.MusicShowChoseMenu())
                                {
                                    case Constants.SHOW_ALL:
                                        Menu.ShowAllMusics();
                                        break;
                                    case Constants.SHOW_BY_NAME:
                                        Band musicBand = new Band();
                                        string musicName = SetInformation.SetMusicName();
                                        var music = SelectInformation.SelectMusicsByName(musicName, musicBand);
                                        Menu.ShowMusics(new List<Music>() { music});
                                        break;
                                    case Constants.SHOW_BY_BAND:
                                        var bands = SelectInformation.SelectAllBand();
                                        var band = bands[Menu.BandSelectMenu()];
                                        var selectedMusics = SelectInformation.SelectMusicsByBandName(band.Name);
                                        Menu.ShowMusics(selectedMusics);
                                        break;
                                    case Constants.SHOW_BY_RATING:
                                        switch (Menu.ChoseSortTypeMenu())
                                        {
                                            case SortType.Ascending:
                                                var sortedMusicAscending = SortingService.SortMusicAscendingRating(SelectInformation.SelectAllMusic());
                                                Menu.ShowMusics(sortedMusicAscending);
                                                break;
                                            case SortType.Descending:
                                                var sortedMusicDescending = SortingService.SortMusicDescendingRating(SelectInformation.SelectAllMusic());
                                                Menu.ShowMusics(sortedMusicDescending);
                                                break;
                                            default:
                                                Console.WriteLine("Нет такого типа сортировки");
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Выберите из предложенных вариантов");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Нет такого объекта");
                                break;
                        }
                        break;
                    case Actions.Exit:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого действия");
                        break;
                }
            } while (!isFinish);
        }
    }
}
