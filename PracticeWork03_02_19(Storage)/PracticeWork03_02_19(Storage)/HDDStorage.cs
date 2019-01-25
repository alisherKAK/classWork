using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    public class HDDStorage : Storage
    {
        public int Speed { get; set; }
        public int SectionQuantity { get; set; }
        public int OneSectionMemory { get; set; }

        public override double GetMemoryValueInMb()
        {
            return FreeMemory + OccupiedMemory;
        }
        public override double GetMemoryValueInGb()
        {
            return (FreeMemory + OccupiedMemory) * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInGb(double memoryValue)
        {
            FreeMemory -= memoryValue * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
            OccupiedMemory += memoryValue * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInMb(double memoryValue)
        {
            FreeMemory -= memoryValue;
            OccupiedMemory += memoryValue;
        }
        public override double GetFreeMemoryValueInMb()
        {
            return FreeMemory;
        }
        public override double GetFreeMemoryValueInGb()
        {
            return FreeMemory / Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override string GetFullInform()
        {
            return $"Name: {_name}\n" +
                   $"Model: {_model}\n" +
                   $"Writing and Reading speed: {Speed}\n" +
                   $"Section quantity: {SectionQuantity}\n" +
                   $"One section memory: {OneSectionMemory}\n" +
                   $"Free memory: {FreeMemory}\n" +
                   $"Occupied memory: {OccupiedMemory}";
        }

        public HDDStorage(int sectionQuantity, int oneSectionMemory)
        {
            Speed = Constants.USB_2_SPEED_IN_MEGABYTE;
            SectionQuantity = sectionQuantity;
            OneSectionMemory = oneSectionMemory;
            FreeMemory = OneSectionMemory * SectionQuantity * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
            OccupiedMemory = Constants.NULL;
        }
    }
}
