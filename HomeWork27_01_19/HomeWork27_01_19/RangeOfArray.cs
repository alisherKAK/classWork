using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork27_01_19
{
    public class RangeOfArray
    {
        #region Свойства
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public int[] Array { get; set; }
        public int this [int index]
        {
            get
            {
                if (index >= RangeStart && index <= RangeEnd)
                {
                    return Array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Не входите в диапозон!");
                }
            }

            set
            {
                if (index >= RangeStart && index <= RangeEnd)
                {
                    Array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Не входите в диапозон!");
                }
            }
        }
        #endregion

        #region Конструкторы
        public RangeOfArray() { RangeStart = 0; }
        #endregion
    }
}
