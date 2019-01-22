using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafter22_01_19
{
    public class Workbench
    {
        public int WorkbenchTableLenth { get; set; }
        public int WorkbenchTableWidth { get; set; }
        public char[,] WorkbenchTable { get; set; }
        public char this[int indexY, int indexX] //вмсето int может быть любой тип
        {
            get
            {
                return WorkbenchTable[indexY, indexX];
            }
            set
            {
                WorkbenchTable[indexY, indexX] = value;
            }
        }

        public static Workbench operator+(Workbench workbench, Materials material)
        {
            workbench[Cursor.cursorYPosition, Cursor.cursorXPosition] = (char)(material + (int)ConsoleKey.D0);
            return workbench;
        }

        public Workbench()
        {
            WorkbenchTableLenth = Constants.STANDART_WORKBENCH_SIZE;
            WorkbenchTableWidth = Constants.STANDART_WORKBENCH_SIZE;
            WorkbenchTable = new char[WorkbenchTableWidth, WorkbenchTableLenth];

            for(int i = 0; i < WorkbenchTableWidth; i++)
            {
                for(int j = 0; j < WorkbenchTableLenth; j++)
                {
                    WorkbenchTable[i, j] = '0';
                }
            }
        }
    }
}
