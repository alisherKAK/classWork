using HomeWork10_05_19.AbstractModels;
using System;

namespace HomeWork10_05_19.Models
{
    public class Comment : Entity
    {
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}
