using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork05_04_19
{
    public class Car
    {
        public 

        public int MaxSpeed { get; set; }
        public int Speed { get; set; }
        public int TraveledDistance { get; set; }

        public void Go()
        {
            TraveledDistance += Speed;
        }
    }
}
