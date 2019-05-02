using ExamWork.ConstantsAndEnums;
using ExamWork.DataAccess;
using ExamWork.Models;
using System;
using System.Linq;

namespace ExamWork.Services
{
    public static class ModelServices
    {
        public static void AddCountry()
        {
            Country newCountry = new Country()
            {
                Name = SetInformations.SetName()
            };

            using(var dataService = new TableDataService<Country>())
            {
                if(!dataService.GetAll().Any(country => country.Name.ToLower() == newCountry.Name.ToLower()))
                {
                    dataService.Add(newCountry);
                }
            }
        }

        public static void AddCity()
        {
            City newCity = new City()
            {
                Name = SetInformations.SetName(),
                Population = SetInformations.SetPopulation(),
                CountryId = SetInformations.SetCountryId()
            };

            using(var dataService = new TableDataService<City>())
            {
                if (newCity.Id != Guid.Empty)
                {
                    if (!dataService.GetAll().Any(city => city.Name.ToLower() == newCity.Name.ToLower() && city.Population == newCity.Population && city.CountryId == newCity.CountryId))
                    {
                        dataService.Add(newCity);
                    }
                }
            }
        }

        public static void AddStreet()
        {
            Street newStreet = new Street()
            {
                Name = SetInformations.SetName(),
                CityId = SetInformations.SetCityId()
            };

            using (var dataService = new TableDataService<Street>())
            {
                if (newStreet.Id == Guid.Empty)
                {
                    if (!dataService.GetAll().Any(street => street.Name.ToLower() == newStreet.Name.ToLower() && street.CityId == newStreet.CityId))
                    {
                        dataService.Add(newStreet);
                    }
                }
            }
        }

        public static void DeleteCountry()
        {
            Guid countryId = SetInformations.SetCountryId();

            using(var dataService = new TableDataService<Country>())
            {
                dataService.DeleteById(countryId);
            }
        }

        public static void DeleteCity()
        {
            Guid cityId = SetInformations.SetCityId();

            using (var dataService = new TableDataService<City>())
            {
                dataService.DeleteById(cityId);
            }
        }

        public static void DeleteStreet()
        {
            Guid streetId = SetInformations.SetStreetId();

            using (var dataService = new TableDataService<Street>())
            {
                dataService.DeleteById(streetId);
            }
        }

        public static void UpdateCountry(Guid countryId, CountryProperties property)
        {
            if (countryId != Guid.Empty)
            {
                switch (property)
                {
                    case CountryProperties.Name:
                        string newName = SetInformations.SetName();
                        using (var dataService = new TableDataService<Country>())
                        {
                            var chosenCountry = dataService.GetAll().Where(country => country.Id == countryId).SingleOrDefault();
                            dataService.DeleteById(countryId);
                            chosenCountry.Name = newName;
                            dataService.Add(chosenCountry);
                        }
                        break;
                }
            }
        }

        public static void UpdateCity(Guid cityId, CityProperties property)
        {
            if (cityId != Guid.Empty)
            {
                switch (property)
                {
                    case CityProperties.Name:
                        string newName = SetInformations.SetName();
                        using (var dataService = new TableDataService<City>())
                        {
                            var chosenCity = dataService.GetAll().Where(city => city.Id == cityId).SingleOrDefault();
                            dataService.DeleteById(cityId);
                            chosenCity.Name = newName;
                            dataService.Add(chosenCity);
                        }
                        break;
                    case CityProperties.Population:
                        int newPopulation = SetInformations.SetPopulation();
                        using (var dataService = new TableDataService<City>())
                        {
                            var chosenCity = dataService.GetAll().Where(city => city.Id == cityId).SingleOrDefault();
                            dataService.DeleteById(cityId);
                            chosenCity.Population = newPopulation;
                            dataService.Add(chosenCity);
                        }
                        break;
                    case CityProperties.CountryId:
                        Guid newCountryId = SetInformations.SetCountryId();
                        if (newCountryId != Guid.Empty)
                        {
                            using (var dataService = new TableDataService<City>())
                            {
                                var chosenCity = dataService.GetAll().Where(city => city.Id == cityId).SingleOrDefault();
                                dataService.DeleteById(cityId);
                                chosenCity.CountryId = newCountryId;
                                dataService.Add(chosenCity);
                            }
                        }
                        break;
                }
            }
        }

        public static void UpdateStreet(Guid streetId, StreetProperties property)
        {
            if (streetId != Guid.Empty)
            {
                switch (property)
                {
                    case StreetProperties.Name:
                        string newName = SetInformations.SetName();
                        using (var dataService = new TableDataService<Street>())
                        {
                            var chosenStreet = dataService.GetAll().Where(street => street.Id == streetId).SingleOrDefault();
                            dataService.DeleteById(streetId);
                            chosenStreet.Name = newName;
                            dataService.Add(chosenStreet);
                        }
                        break;
                    case StreetProperties.CityId:
                        Guid newCityId = SetInformations.SetCityId();
                        if (newCityId != Guid.Empty)
                        {
                            using (var dataService = new TableDataService<Street>())
                            {
                                var chosenStreet = dataService.GetAll().Where(street => street.Id == streetId).SingleOrDefault();
                                dataService.DeleteById(streetId);
                                chosenStreet.CityId = newCityId;
                                dataService.Add(chosenStreet);
                            }
                        }
                        break;
                }
            }
        }
    }
}
