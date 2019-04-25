using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02_05_19.Services
{
    public static class Menu
    {
        public static Actions ActionMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите действие:\n" +
                                      "1) Добавить\n" +
                                      "2) Пойск\n" +
                                      "3) Выход");

                    int action;

                    if(int.TryParse(Console.ReadLine().Trim(), out action))
                    {
                        return (Actions)action;
                    }

                    throw new ArgumentException("Число было введено некоректно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Models AddMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Что вы хотите добавить:\n" +
                                      "1) Группу\n" +
                                      "2) Музыку");

                    int addModel;

                    if(int.TryParse(Console.ReadLine().Trim(), out addModel))
                    {
                        return (Models)addModel;
                    }

                    throw new ArgumentException("Число было некоректно введено");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int BandSelectMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите группу, если ее нет тогда нажмите на '0'");

                    var bands = SelectInformation.SelectAllBand();

                    for (int i = 0; i < bands.Count; i++)
                    {
                        Console.WriteLine($"{i+Constants.LENGTH_TO_INDEX} {bands[i].Name}");
                    }

                    int bandIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out bandIndex)) 
                    {
                        if(bandIndex >= Constants.FIRST_ELEMENT_INDEX && bandIndex <= bands.Count)
                        {
                            return bandIndex - Constants.LENGTH_TO_INDEX;
                        }

                        throw new ArgumentException("Нет группы с таким номером");
                    }

                    throw new ArgumentException("Число было введено некоректно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Models WhatShow()
        {
            do
            {
                try
                {
                    Console.WriteLine("Что вы хотите искать:\n" +
                                      "1) Группу\n" +
                                      "2) Музку");

                    int model;

                    if(int.TryParse(Console.ReadLine().Trim(), out model))
                    {
                        return (Models)model;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                } 
            } while (true);
        }

        public static void ShowAllBands()
        {
            using (var context = new MusicContext())
            {
                foreach (Band band in context.Bands.ToList())
                {
                    Console.WriteLine($"{band.Name}");
                }
            }
        }

        public static void ShowAllMusics()
        {
            using (var context = new MusicContext())
            {
                foreach (Music music in context.Musics.ToList())
                {
                    Console.WriteLine($"{music.Name}-{music.Band.Name} {music.SongDurationInSeconds/Constants.SECOND_IN_ONE_MINUTE}:{music.SongDurationInSeconds % Constants.SECOND_IN_ONE_MINUTE}");
                }
            }
        }

        public static void ShowBands(List<Band> bands)
        {
            for(int i = 0; i < bands.Count; i++)
            {
                Console.WriteLine($"{i+1}) {bands[i].Name}");
            }
        }

        public static void ShowMusics(List<Music> musics)
        {
            for(int i = 0; i < musics.Count; i++)
            {
                Console.WriteLine($"{musics[i].Name} {musics[i].SongDurationInSeconds/Constants.SECOND_IN_ONE_MINUTE}:{musics[i].SongDurationInSeconds % Constants.SECOND_IN_ONE_MINUTE}");
            }
        }

        public static int MusicShowChoseMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Как вы вывести группы:\n" +
                                      "1) Пойск по имени\n" +
                                      "2) Вывести все\n" +
                                      "3) Пойск по группе\n" +
                                      "4) Вывести по рейтенгу");

                    int chose;

                    if (int.TryParse(Console.ReadLine().Trim(), out chose))
                    {
                        return chose;
                    }

                    throw new ArgumentException("Чило было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static SortType ChoseSortTypeMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите тип сортировки:\n" +
                                      "1) По возрастанию\n" +
                                      "2) По убыванию");

                    int sortType;

                    if(int.TryParse(Console.ReadLine().Trim(), out sortType))
                    {
                        return (SortType)sortType;
                    }

                    throw new ArgumentException("Чило было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
