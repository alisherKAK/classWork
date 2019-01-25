using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    public abstract class Storage
    {
        public double FreeMemory { get; set; }
        public double OccupiedMemory { get; set; }
        protected string _name;
        protected string _model;

        public abstract double GetMemoryValueInMb();
        public abstract double GetMemoryValueInGb();
        public abstract void CopyInStorageInGb(double memoryValue);
        public abstract void CopyInStorageInMb(double memoryValue);
        public abstract double GetFreeMemoryValueInMb();
        public abstract double GetFreeMemoryValueInGb();
        public abstract string GetFullInform(); 
    }
}
