using System;

namespace Market.Services
{
    public static class SetInformation
    {
        public static string SetProductName()
        {
            try
            {
                Console.WriteLine("Введите имя продкута");

                string name = Console.ReadLine().Trim();

                for (int i = 0; i < name.Length; i++)
                {
                    if (!(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z') && !(name[i] >= 'А' && name[i] <= 'Я'))
                    {
                        throw new ArgumentException("Имя продукта было введено неверно");
                    }
                }

                return name;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetProductName();
            }
        }

        public static double SetProductPrice()
        {
            try
            {
                Console.WriteLine("Введите цену продука:");

                double price;

                if (double.TryParse(Console.ReadLine().Trim(), out price) && price >= 0)
                {
                    return price;
                }

                throw new ArgumentException("Цена была введена неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetProductPrice();
            }
        }

        public static int SetProductQuantity()
        {
            try
            {
                Console.WriteLine("Введите кол продуктов:");

                int quantity;

                if (int.TryParse(Console.ReadLine().Trim(), out quantity) && quantity >= 0)
                {
                    return quantity;
                }

                throw new ArgumentException("Кол было введено неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetProductQuantity();
            }
        }
    }
}
