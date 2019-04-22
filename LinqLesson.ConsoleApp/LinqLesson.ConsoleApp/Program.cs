using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLesson.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new GameContext())
            {
                //List<Hero> result = new List<Hero>();
                //foreach(var hero in context.Heroes.ToList())
                //{
                //    if(hero.Nickname.Contains("H"))
                //    {
                //        result.Add(hero);
                //    }
                //}
                var result = from hero
                             in context.Heroes
                             where hero.Nickname.Contains("H")
                             orderby hero.Nickname
                             descending
                             select hero;

                var anotherResult = context.Heroes.Where(hero => hero.Nickname.Contains("H")).ToList();
                var sword = context.Weapons.SingleOrDefault();

                var name = "Ivan";
                int legth = name.GetLength();
            }
        }
    }
}
