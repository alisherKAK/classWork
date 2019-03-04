using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialisation
{
    [Serializable]
    public class Person
    {
        [NonSerialized]
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
