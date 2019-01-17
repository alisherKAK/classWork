using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class Person
    {
        // autoproperty(автосвойства) 
        // public тип Имя { get; set; }
        //prop 2 раз таб

        public int Id { get; set; }

        //private int _id;
        //public int GetId() { return _id; }
        //public void SetId(int id) { _id = id; }

        /* propperty (свойство)
         * private тип переменная
         * public тип Имя 
         * {
         *      get
         *      {
         *          какой то код
         *          return переменная;
         *      }
         *      
         *      set
         *      {
         *          какой то код
         *          переменная = value;
         *      }
         * }
        */
        private string _fullName;
        public string FullName
        {
            get
            {
                string result = $"Увожаемый(ая) {_fullName}";
                return result;
            }
            set
            {
                _fullName = value;
            }
        }

        public string[] Nicknames { get; set; }
        public string this [int index] //вмсето int может быть любой тип
        {
            get
            {
                return Nicknames[index];
            }
            set
            {
                Nicknames[index] = value;
            }
        }
    }
}
