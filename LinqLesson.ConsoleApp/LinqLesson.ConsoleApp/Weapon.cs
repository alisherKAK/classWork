using System;
using System.Collections.Generic;

namespace LinqLesson.ConsoleApp
{
    public class Weapon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Damage { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}