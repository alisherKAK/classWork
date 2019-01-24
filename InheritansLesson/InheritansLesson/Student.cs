using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritansLesson
{
    public class Student : Person
    {
        public string GroupName { get; set; }
        public double AverageMark { get; set; }

        public Student(string fullName) : base(fullName)
        {
        }
    }
}
