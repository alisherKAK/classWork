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
                                var band = ModelCreator.CreateBand();
                                SaveModelsInDataBase.SaveBand(band);
                                break;
                            case Services.Models.Music:
                                do
                                {
                                    try
                                    {
                                        var musicsBand = SelectInformation.SelectBandByIndex(Menu.BandSelectMenu());
                                        var music = ModelCreator.CreateMusic(musicsBand);
                                        SaveModelsInDataBase.SaveMusic(music);
                                        break;
                                    }
                                    catch(ArgumentOutOfRangeException)
                                    {
                                        Console.WriteLine("Добвление новой группы:");
                                        var newBand = ModelCreator.CreateBand();
                                        SaveModelsInDataBase.SaveBand(newBand);
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
                                        string musicName = SetInformation.SetMusicName();
                                        var musics = SelectInformation.SelectMusicsByName(musicName);
                                        Menu.ShowMusics(musics);
                                        break;
                                    case Constants.SHOW_BY_BAND:
                                        using (var context = new MusicContext())
                                        {
                                            var bands = context.Bands.ToList();
                                            Menu.ShowMusics(SelectInformation.SelectMusicsByBandName(bands[Menu.BandSelectMenu()].Name));
                                        }
                                        break;
                                    default:
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
