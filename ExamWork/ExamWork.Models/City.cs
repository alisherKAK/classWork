using ExamWork.AbstractModels;
using System;

namespace ExamWork.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Guid CountryId { get; set; }
    }
}
