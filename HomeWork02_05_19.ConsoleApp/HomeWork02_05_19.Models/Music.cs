using HomeWork02_05_19.AbstractModels;
using System;

namespace HomeWork02_05_19.Models
{
    public class Music : Entity
    {
        public string Name { get; set; }
        public Guid BandId { get; set; }
        public Band Band { get; set; }
        public string Lyrics { get; set; }
        public int SongDurationInSeconds { get; set; }
        public int Rating { get; set; }
    }
}
