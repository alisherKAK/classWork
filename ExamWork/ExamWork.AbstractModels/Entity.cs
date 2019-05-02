using System;

namespace ExamWork.AbstractModels
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
