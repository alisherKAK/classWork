using HomeWork10_05_19.ConstantsAndEnums;
using HomeWork10_05_19.DataAccess;
using HomeWork10_05_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10_05_19.Services
{
    public static class Menu
    {
        public static UserActions ChoseUserActionMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Write news\n" +
                                      "2) Write comment\n" +
                                      "3) Exit");

                    int userAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out userAction))
                    {
                        return (UserActions)userAction;
                    }

                    throw new ArgumentException("Number was wrote incorrect");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Theme ThemeChoseMenu()
        {
            do
            {
                try
                {
                    TableDataService<Theme> dataServiceForThemes = new TableDataService<Theme>();
                    var themes = dataServiceForThemes.GetAll();

                    Console.WriteLine("Chose news theme");
                    for (int i = 0; i < themes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} {themes[i].Name}");
                    }

                    int themeIndex;

                    if (int.TryParse(Console.ReadLine().Trim(), out themeIndex))
                    {
                        return themes[themeIndex - 1];
                    }

                    throw new ArgumentException("Number was wrote incorrect"); 
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static NewsAuthor NewsAuthorChoseMenu()
        {

        }

        public static void NewsWriteMenu()
        {
            
        }
    }
}
