namespace MagazineSubscriptions.DataAccess
{
    using MagazineSubscriptions.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MagazineContext : DbContext
    {
        // Контекст настроен для использования строки подключения "MagazineContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "MagazineSubscriptions.DataAccess.MagazineContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MagazineContext" 
        // в файле конфигурации приложения.
        public MagazineContext()
            : base("name=MagazineContext")
        {
            Database.SetInitializer(new SubscriptionsInitializer());
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersSubscription> UsersSubscriptions { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<MagazineShipping> MagazineShippings { get; set; }

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