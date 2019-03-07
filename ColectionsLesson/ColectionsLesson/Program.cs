using System;
using System.Collections;
using System.Collections.Generic;

namespace ColectionsLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Array.Resize(ref numbers, numbers.Length + 1);
            numbers[numbers.Length - 1] = 6;

            ArrayList list = new ArrayList { 1, 2, 3, 4, 5 };
            list.Add(6);
            list.Remove(2);
            list.RemoveAt(0);
            list.Add("");
            list.Add(new NullReferenceException());

            List<int> numbersAsList = new List<int> { 1, 2, 3, 4, 5 };
            numbersAsList.Add(6);
            Console.WriteLine(numbersAsList[2]);

            Dictionary<DayOfWeek, List<string>> mealSchedule = new Dictionary<DayOfWeek, List<string>>();
            mealSchedule.Add(DayOfWeek.Monday, new List<string>
            {
                "Каша",
                "Борщ",
                "Омаров под сливочным соусом"
            });
        }
    }
}
