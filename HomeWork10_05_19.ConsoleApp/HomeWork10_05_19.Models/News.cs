using HomeWork10_05_19.AbstractModels;
using System;

namespace HomeWork10_05_19.Models
{
    public class News : Entity
    {
        public Guid ThemeId { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
