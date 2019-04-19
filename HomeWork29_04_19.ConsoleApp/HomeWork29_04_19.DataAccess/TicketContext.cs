namespace HomeWork29_04_19.DataAccess
{
    using HomeWork29_04_19.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TicketContext : DbContext
    {
        // Контекст настроен для использования строки подключения "TicketContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "HomeWork29_04_19.DataAccess.TicketContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "TicketContext" 
        // в файле конфигурации приложения.
        public TicketContext()
            : base("name=TicketContext")
        {
        }

        public DbSet<Spot> Spots { get; set; }
        public DbSet<Stateroom> Staterooms { get; set; }
        public DbSet<RailwayCarriage> RailwayCarriages { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatForTicket> SeatsForTickets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}