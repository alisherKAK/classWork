using HomeWork02_05_19.AbstractModels;

namespace HomeWork02_05_19.Models
{
    public class Music : Entity
    {
        public string Name { get; set; }
        public Band Band { get; set; }
        public string Lyrics { get; set; }
        public int SongDurationInSeconds { get; set; }
        public int Rating { get; set; }
    }
}
