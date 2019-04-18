using HomeWork28_04_19.DataAccess;
using HomeWork28_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28_04_19.Services
{
    public static class SetInformations
    {
        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя посетителя:");

                    string name = Console.ReadLine().Trim();

                    for(int i = 0; i < name.Length; i++)
                    {
                        if( !(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z'))
                        {
                            throw new ArgumentException("Имя было введено неверно");
                        }
                    }

                    return name;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetCertificateNumber()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите номер удостоверения личности посетителя:");

                    string certificateNumber = Console.ReadLine().Trim();

                    if(certificateNumber.Length == Constants.CERTIFICATE_NUMBER_LENGTH)
                    {
                        for(int i = 0; i < certificateNumber.Length; i++)
                        {
                            if(!(certificateNumber[i] >= '0' && certificateNumber[i] <= '9'))
                            {
                                throw new ArgumentException("В номере должны быть только цифры");
                            }
                        }

                        return certificateNumber;
                    }

                    throw new ArgumentException("Длинна введеного номера не соответствует номеру удостоверения личности");
                }
                catch (Exception)
                {

                    throw;
                }
            } while (true);
        }

        public static Guid SetPersonId()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите номер человека который уходит:");

                    List<Person> persons;

                    using (var context = new LedgerContext())
                    {
                        persons = context.People.ToList();

                        if (persons.Count == Constants.NULL)
                        {
                            throw new ArgumentNullException("Нет людей");
                        }

                        for (int i = 0; i < persons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) {persons[i].Name} : {persons[i].CertificateNumber}");
                        }
                    }
                    int personId;

                    if(int.TryParse(Console.ReadLine().Trim(), out personId))
                    {
                        if(personId > 0 && personId <= persons.Count)
                        {
                            return persons[personId-1].Id;
                        }

                        throw new ArgumentException("Нет такого номера, выберите существующи");
                    }

                    throw new ArgumentException("Номер был некоректно введен");
                }
                catch(ArgumentNullException)
                {
                    throw;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetVisitPurpose()
        {
            Console.WriteLine("Введите причину прихода посетителя:");

            string visitPurpose = Console.ReadLine().Trim();

            return visitPurpose;
        }
    }
}
