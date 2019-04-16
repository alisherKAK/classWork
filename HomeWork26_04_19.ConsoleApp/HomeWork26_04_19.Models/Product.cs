using HomeWork26_04_19.AbstractModels;
using System;

namespace HomeWork26_04_19.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Producer Producer { get; set; }
        public Guid ProducerId { get; set; }
    }
}
