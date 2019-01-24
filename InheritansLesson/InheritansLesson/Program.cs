using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritansLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person teacher = new Teacher("Oleg");
            Person student = new Student("Ivan");
            //Person firstPerson = new Person();

            Person[] people = new Person[] { teacher, student };

            foreach(var person in people)
            {
                if(person is Teacher)
                {
                    //((Teacher)person).SubjectName = "Math";
                    (person as Teacher).SubjectName = "Math";
                }
                else if(person is Student)
                {
                    (person as Student).AverageMark = 4.7;
                }
            }
        }
    }
}
