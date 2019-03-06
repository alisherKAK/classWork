using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class DirectorsCompany<T> where T:Employee, IManager, new()
    {
        private readonly List<T> _managers;

        public DirectorsCompany(List<T> managers)
        {
            _managers = managers;
        }

        public void DoWorkTogether()
        {
            foreach(var manager in _managers)
            {
                manager.DoStaff();
                //T element = new T();
            }
        }
    }
}
