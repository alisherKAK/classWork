using HomeWork02_05_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork02_05_19.Models
{
    public class Band : Entity
    {
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
