using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork05_04_19
{
    public class BankAccount : IPropertychanged
    {
        public event PropertyeventHandler Propertychanged;

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                Propertychanged.Invoke(this, new PropertyeventArgs("Fullname"));
            }
        }
        private int _sum;
        public int Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
                Propertychanged.Invoke(this, new PropertyeventArgs("Sum"));
            }
        }
    }
}
