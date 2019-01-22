using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafter22_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbench workbench = new Workbench();
            bool isFinish = false;

            WorkbenchPrint(workbench);
            while (true)
            {
                ConsoleKeyInfo info;
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if(Cursor.cursorXPosition != Constants.NULL)
                        {
                            Cursor.cursorXPosition = Cursor.cursorXPosition - Constants.LENTH_TO_INDEX;
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        else
                        {
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Cursor.cursorXPosition != workbench.WorkbenchTableLenth - Constants.LENTH_TO_INDEX)
                        {
                            Cursor.cursorXPosition = Cursor.cursorXPosition + Constants.LENTH_TO_INDEX;
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        else
                        {
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if(Cursor.cursorYPosition != Constants.NULL)
                        {
                            Cursor.cursorYPosition = Cursor.cursorYPosition - Constants.LENTH_TO_INDEX;
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        else
                        {
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Cursor.cursorYPosition != workbench.WorkbenchTableWidth - Constants.LENTH_TO_INDEX)
                        {
                            Cursor.cursorYPosition = Cursor.cursorYPosition + Constants.LENTH_TO_INDEX;
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        else
                        {
                            Console.Clear();
                            WorkbenchPrint(workbench);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isFinish = true;
                        break;
                    case ConsoleKey.D0:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '0';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    case ConsoleKey.D1:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '1';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    case ConsoleKey.D2:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '2';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    case ConsoleKey.D3:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '3';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    case ConsoleKey.D4:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '4';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    case ConsoleKey.D5:
                        workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = '5';
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                    default:
                        Console.Clear();
                        WorkbenchPrint(workbench);
                        break;
                }
                if(isFinish == true)
                {
                    break;
                }
            }
        }
        static bool RecipeCheck(Workbench workbench)
        {
            switch (workbench.WorkbenchTable)
            {
                case InstrumentsRecipe.WoodShovelFirstRecipe:
                    break;
            }

            return false;
        }
        static void WorkbenchPrint(Workbench workbench)
        {
            for (int i = 0; i < workbench.WorkbenchTableWidth; i++)
            {
                for (int j = 0; j < workbench.WorkbenchTableLenth; j++)
                {
                    if(i == Cursor.cursorYPosition && j == Cursor.cursorXPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(workbench[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(workbench[i, j]);
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
