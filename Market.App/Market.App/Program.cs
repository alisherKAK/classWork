using Market.Models;
using Market.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Market.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (File.Create("trolley.txt")) ;

            bool isFinish = false;
            ProductCreater creater = new ProductCreater();
            Trolley trolley = new Trolley();

            creater.KeyPressEvent += Creater_KeyPressEvent;

            while (true)
            {
                switch (Chose())
                {
                    case Constants.ADD_CHOSE:
                        creater.CreateAndSave(trolley);
                        break;
                    case Constants.EXIT_CHOSE:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нету такого выбора");
                        break;
                }

                if (isFinish == true)
                {
                    break;
                }
            }

            // 1) Нет нельзя, можно задать строку но не изменить, а разные операторы и методы возвращают обновленную строку

            // 2) Инструмент для вскрытия решении
            //    Assembly assembly = Assembly.LoadFile(string path);

            // 3) Преобразовние объекта в поток байтов. Пример:
            // XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            // using (FileStream stream = new FileStream('trolley.txt', FileMode.Truncate))
            // {
            //     serializer.Serialize(stream, trolley.Products);
            // }

            //4) В Market.Models есть класс TableDataService

            //5) Плюсы Interface: очень гибкие в плане множественного наследования, обобщают какое или какие либо действия
            //   Минусы Interface: нету дефолтной реализаций
            //   Плюсы Abstarct Class: Может иметь дефолтную реализацию матодов, обобщают какое или какие либо действия
            //   Минусы Abstarct Class: Не может возможности множественного наследия

            //6) nullable тип это тот тип который может принять null значение, у классов nullable стойти по дефолту, а у структур нужно писать nullable или знак вопроса после имя типа. Это нужно чтобы тип принемал null значение при ситуациях который могут вернуть null значение
        }

        private static void Creater_KeyPressEvent(Trolley trolley, Product product)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

            using (FileStream stream = new FileStream("trolley.txt", FileMode.Truncate))
            {
                serializer.Serialize(stream, trolley.Products);
            }
        }

        public static int Chose()
        {
            try
            {
                Console.WriteLine("1) Добавить продукт\n" +
                                  "2) Выход");

                int chose;

                if (int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    return chose;
                }

                throw new ArgumentException("Число было введено неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return Chose();
            }
        }
    }
}
