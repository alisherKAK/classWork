using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespacesLesson15_01_19
{
    namespace AnotherNamespace
    {
        public class AnotherClass
        {
            public void DoWork(string data)
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new ArgumentException();
                }

                //если аргумент не пустой то тут идет какая-то работа
            }
        }
    }
}
