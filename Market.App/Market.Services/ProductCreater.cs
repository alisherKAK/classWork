using Market.Models;
using System;

namespace Market.Services
{
    public delegate void KeyPressDelegate(Trolley trolley, Product product);

    public class ProductCreater
    {
        public event KeyPressDelegate KeyPressEvent;

        public void CreateAndSave(Trolley trolley)
        {
            Product newProduct = new Product()
            {
                Name = SetInformation.SetProductName(),
                Price = SetInformation.SetProductPrice(),
                Quantity = SetInformation.SetProductQuantity()
            };

            Console.WriteLine("Нажмите Ctrl + S чтобы добавить продукт");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Modifiers == ConsoleModifiers.Control && keyInfo.Key == ConsoleKey.S)
            {
                trolley.Products.Add(newProduct);
                KeyPressEvent.Invoke(trolley, newProduct);
            }
            else
            {
                Console.WriteLine("Продукт не был добавлен");
            }
        }
    }
}
