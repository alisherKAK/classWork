using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPerson = new Person();
            firstPerson.Id = 1; //set
            int id = firstPerson.Id; //get
            Console.WriteLine(firstPerson.Id);

            var secondPerson = new Person
            {
                Id = 2,
                FullName = "Kakto tak"
            };

            secondPerson.Nicknames = new string[] { "", "" };
            secondPerson.Nicknames[0] = "";
            secondPerson[0] = "значение";

            int[] numbers = { 1, 2, 3, 4, 5 };
            Array.Resize(ref numbers, 20);
            numbers[0] = 12;
        }
    }
}
