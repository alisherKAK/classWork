namespace HomeWork05_05_19.DataAccess.Migrations
{
    using HomeWork05_05_19.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeWork05_05_19.DataAccess.CityPhoneNumberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeWork05_05_19.DataAccess.CityPhoneNumberContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Cities.AddRange(new List<City>()
            {
                new City() { Name = "������", CityPhoneCode = "7172"},
                new City() { Name = "������", CityPhoneCode = "727"},
                new City() { Name = "��������", CityPhoneCode = "33622"},
                new City() { Name = "�����", CityPhoneCode = "7292"},
                new City() { Name = "������", CityPhoneCode = "7132"},
                new City() { Name = "������", CityPhoneCode = "7122"},
                new City() { Name = "������", CityPhoneCode = "71036"},
                new City() { Name = "�������", CityPhoneCode = "71630"},
                new City() { Name = "����������", CityPhoneCode = "7102"},
                new City() { Name = "���������", CityPhoneCode = "7212"},
                new City() { Name = "��������", CityPhoneCode = "7162"},
                new City() { Name = "��������", CityPhoneCode = "7142"},
                new City() { Name = "����������", CityPhoneCode = "72422"},
                new City() { Name = "��������", CityPhoneCode = "7182"},
                new City() { Name = "�������������", CityPhoneCode = "7222"},
                new City() { Name = "�����", CityPhoneCode = "72622"},
                new City() { Name = "�����������", CityPhoneCode = "7282"},
                new City() { Name = "�������", CityPhoneCode = "7112"},
                new City() { Name = "����-�����������", CityPhoneCode = "7232"},
                new City() { Name = "�������", CityPhoneCode = "7252"}
            });

            context.SaveChanges();
        }
    }
}
