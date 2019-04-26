using MagazineSubscriptions.AbstractModels;
using System;

namespace MagazineSubscriptions.Models
{
    public class Magazine : Entity
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
