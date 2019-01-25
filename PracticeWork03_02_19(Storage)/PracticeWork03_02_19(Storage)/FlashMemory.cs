using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    public class FlashMemory : Storage
    {
        public double Speed { get; set; }

        public override double GetMemoryValueInMb()
        {
            return FreeMemory + OccupiedMemory;
        }
        public override double GetMemoryValueInGb()
        {
            return (FreeMemory + OccupiedMemory)/Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInGb(double memoryValueInMb)
        {
            FreeMemory -= memoryValueInMb/Constants.IN_GIGABYTE_MEGABYTE_COUNT;
            OccupiedMemory += memoryValueInMb/Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInMb(double memoryValueInMb)
        {
            FreeMemory -= memoryValueInMb;
            OccupiedMemory += memoryValueInMb;
        }
        public override double GetFreeMemoryValueInMb()
        {
            return FreeMemory;
        }
        public override double GetFreeMemoryValueInGb()
        {
            return FreeMemory/Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override string GetFullInform()
        {
            return $"Name: {_name}\n" +
                   $"Model: {_model}\n" +
                   $"Writing and Reading speed(Mb/s): {Speed}\n" +
                   $"Free memory(Mb): {FreeMemory}\n" +
                   $"Occupied memory(Mb): {OccupiedMemory}";
        }

        public FlashMemory(double memoryInMb)
        {
            Speed = Constants.USB_3_SPEED_IN_MEGABYTE;
            FreeMemory += memoryInMb;
            OccupiedMemory = Constants.NULL;
        }
    }
}
