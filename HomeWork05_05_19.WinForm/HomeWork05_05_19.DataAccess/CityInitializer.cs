using HomeWork05_05_19.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace HomeWork05_05_19.DataAccess
{
    class CityInitializer : CreateDatabaseIfNotExists<CityPhoneNumberContext>
    {
        protected override void Seed(CityPhoneNumberContext context)
        {
            context.Cities.AddRange(new List<City>()
            {
                new City() { Name = "Астана", CityPhoneCode = "7172"},
                new City() { Name = "Алматы", CityPhoneCode = "727"},
                new City() { Name = "Байконыр", CityPhoneCode = "33622"},
                new City() { Name = "Актау", CityPhoneCode = "7292"},
                new City() { Name = "Актобе", CityPhoneCode = "7132"},
                new City() { Name = "Атырау", CityPhoneCode = "7122"},
                new City() { Name = "Балхаш", CityPhoneCode = "71036"},
                new City() { Name = "Боровое", CityPhoneCode = "71630"},
                new City() { Name = "Джезказган", CityPhoneCode = "7102"},
                new City() { Name = "Караганда", CityPhoneCode = "7212"},
                new City() { Name = "Кокшетау", CityPhoneCode = "7162"},
                new City() { Name = "Костанай", CityPhoneCode = "7142"},
                new City() { Name = "Кызылдорда", CityPhoneCode = "72422"},
                new City() { Name = "Павлодар", CityPhoneCode = "7182"},
                new City() { Name = "Семипалатинск", CityPhoneCode = "7222"},
                new City() { Name = "Тараз", CityPhoneCode = "72622"},
                new City() { Name = "Талдыкорган", CityPhoneCode = "7282"},
                new City() { Name = "Уральск", CityPhoneCode = "7112"},
                new City() { Name = "Усть-Каменогорск", CityPhoneCode = "7232"},
                new City() { Name = "Шымкент", CityPhoneCode = "7252"}
            });

            context.SaveChanges();
        }
    }
}
