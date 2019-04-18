namespace HomeWork28_04_19.DataAccess
{
    using HomeWork28_04_19.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LedgerContext : DbContext
    {
        // Контекст настроен для использования строки подключения "LedgerContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "HomeWork28_04_19.DataAccess.LedgerContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "LedgerContext" 
        // в файле конфигурации приложения.
        public LedgerContext()
            : base("name=LedgerContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }

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