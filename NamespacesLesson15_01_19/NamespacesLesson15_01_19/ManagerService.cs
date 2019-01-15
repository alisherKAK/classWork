using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespacesLesson15_01_19.AnotherNamespace;

namespace NamespacesLesson15_01_19
{
    public static class ManagerService
    {
        public static void Operate()
        {
            AnotherClass anotherClass = new AnotherClass();
            anotherClass.DoWork("");
        }
    }
}
