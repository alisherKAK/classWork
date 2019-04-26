using System;

namespace MagazineSubscriptions.AbstractModels
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
