using System;

namespace DbUpLesson.ConsoleApp
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Passwrod { get; set; }
    }
}
