namespace HomeWork05_05_19.DataAccess
{
    using HomeWork05_05_19.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CityPhoneNumberContext : DbContext
    {
        // Контекст настроен для использования строки подключения "CityPhoneNumberContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "HomeWork05_05_19.DataAccess.CityPhoneNumberContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "CityPhoneNumberContext" 
        // в файле конфигурации приложения.
        public CityPhoneNumberContext()
            : base("name=CityPhoneNumberContext")
        {
            Database.SetInitializer(new CityInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CityPhoneNumber> CityPhoneNumbers { get; set; }

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