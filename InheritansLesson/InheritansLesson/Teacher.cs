using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritansLesson
{
    public sealed class Teacher : Person
    {
        public string SubjectName { get; set; }

        public Teacher(string fullName) : base(fullName)
        {
        }

        public new string GetFullInform()
        {
            return $"{Id}, {FullName}, {Age}";
        }

        public override void MakeWork()
        {
            //Какая-то базовая реализация
        }

        public override string ToString()
        {
            return GetFullInform();
        }

        public override void ToDo()
        {
            throw new NotImplementedException();
        }
    }
}
