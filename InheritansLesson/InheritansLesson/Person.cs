using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritansLesson
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public Person(string fullName)
        {
            FullName = fullName;
        }

        public string GetFullInform()
        {
            return $"{Id}, {FullName}, {Age}";
        }

        public virtual void MakeWork()
        {
            //Какая-то базовая реализация
        }

        public abstract void ToDo();
    }
}
