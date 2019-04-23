namespace HomeWork02_05_19.DataAccess
{
    using HomeWork02_05_19.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MusicContext : DbContext
    {
        // Контекст настроен для использования строки подключения "MusicContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "HomeWork02_05_19.DataAccess.MusicContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MusicContext" 
        // в файле конфигурации приложения.
        public MusicContext()
            : base("name=MusicContext")
        {
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Music> Musics { get; set; }

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