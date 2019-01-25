using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraBus
{
    class Program
    {
        static void Main(string[] args)
        {

            int lastBusNumber = Constants.NULL;
            bool isPaid = false;
            bool isFinish = false;
            bool isSited = false;

            Bus bus = new Bus();
            Card card = new Card();

            while (true)
            {
                switch (Choice())
                {
                    case Constants.FIRST_CHOICE:
                        TopUpBalance(card);
                        break;
                    case Constants.SECOND_CHOICE:
                        SitOnBus(bus, ref isSited, ref lastBusNumber);
                        break;
                    case Constants.THIRD_CHOICE:
                        if (isSited == true)
                        {
                            GetOffTheBus(ref isSited, ref isPaid);
                        }
                        break;
                    case Constants.FOURTH_CHOICE:
                        RideOnBus(bus, card, ref isSited, lastBusNumber, ref isPaid);
                        break;
                    case Constants.FIFTH_CHOICE:
                        BalanceShow(card);
                        break;
                    case Constants.SIXTH_CHOICE:
                        isFinish = true;
                        break;
                }

                if(isFinish == true)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        static void GetOffTheBus(ref bool isSited, ref bool isPaid)
        {
            Console.Clear();
            Console.Write("Вы вышли с автобуса");
            isSited = false;
            isPaid = false;
            Console.ReadKey(true);
        }
        static void RideOnBus(Bus bus, Card card, ref bool isSited, int lastBusNumber, ref bool isPaid)
        {
            Console.CursorVisible = true;
            Console.Clear();

            if (isSited == true)
            {
                if (card.Preferential == false)
                {
                    Console.WriteLine("Вы плтите детский или взрослый билет(c/a): ");

                    if (isPaid == false && lastBusNumber == bus.BusNumber)
                    {
                        while (true)
                        {
                            string choice = Console.ReadLine();

                            if (choice == "c" || choice == "C" || choice == "Child" || choice == "CHILD")
                            {
                                if (card.Cash >= bus.ChildrenTicketPrice)
                                {
                                    card.WithdrawMoney(bus.ChildrenTicketPrice);
                                    isPaid = true;
                                    Console.Write("Все хорошо можете ездить");
                                    Console.CursorVisible = false;
                                    Console.ReadKey(true);
                                    return;
                                }
                                else
                                {
                                    Console.Write("Вам не хвотает денег!");
                                    Console.CursorVisible = false;
                                    Console.ReadKey(true);
                                    isPaid = false;
                                    isSited = false;
                                    return;
                                }
                            }
                            else if (choice == "a" || choice == "A" || choice == "Adult" || choice == "ADULT")
                            {
                                if (card.Cash >= bus.AdultTicketPrice)
                                {
                                    card.WithdrawMoney(bus.AdultTicketPrice);
                                    isPaid = true;
                                    Console.Write("Все хорошо можете ездить");
                                    Console.CursorVisible = false;
                                    Console.ReadKey(true);
                                    return;
                                }
                                else
                                {
                                    Console.Write("Вам не хватает денег!");
                                    isPaid = false;
                                    Console.CursorVisible = false;
                                    Console.ReadKey(true);
                                    isSited = false;
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы уже заплатили за проезд!");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    Console.Write("Вы проехали какое-то расстояние");
                    Console.CursorVisible = false;
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.Write("Вы не сели в автобус");
                Console.CursorVisible = false;
                Console.ReadKey(true);
            }
        }
        static void SitOnBus(Bus bus, ref bool isSited, ref int lastBusNumber)
        {
            Console.Clear();
            Console.CursorVisible = true;

            if (isSited == false)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("На какой автобус вы хотите сесть( 1~99 внутри города, 100~199 экспресс внутр города, 300~399 пригородные ): ");

                        int busNumber = Constants.NULL;

                        if (int.TryParse((Console.ReadLine()).Trim(), out busNumber))
                        {
                            bus.BusNumber = busNumber;
                            lastBusNumber = busNumber;
                            isSited = true;
                            break;
                        }

                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                        isSited = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Значало нужно выйти из другого автобуса");
                Console.ReadKey(true);
            }
        }
        static void TopUpBalance(Card card)
        {
            Console.Clear();
            Console.CursorVisible = true;
            while (true)
            {
                try
                {
                    Console.WriteLine("Вы относитесь к льготной группе(y/n): ");

                    string choice = Console.ReadLine();

                    if (choice == "y" || choice == "Y" || choice == "Yes" || choice == "yes" || choice == "YES")
                    {
                        card.Preferential = true;
                        break;
                    }
                    else if (choice == "n" || choice == "N" || choice == "No" || choice == "no" || choice == "NO")
                    {
                        card.Preferential = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Вы ввели неправильно!");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            if(card.Preferential == true)
            {
                Console.Write("Вам бесплано на все автобусы!");
                Console.Read();
            }
            else
            {

                while (true)
                {
                    Console.WriteLine("На какую сумму вы хотите поплнить карту: ");

                    double sum = Constants.NULL;

                    try
                    {
                        if (double.TryParse(Console.ReadLine(), out sum))
                        {
                            card.PutMoney(sum);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("Вы ввели неправильную сумму");
                        }
                    }
                    catch(ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
        static void BalanceShow(Card card)
        {
            Console.Clear();
            Console.Write($"Your balance: {card.Cash}");

            while (true)
            {
                ConsoleKeyInfo info;

                info = Console.ReadKey(true);

                switch (info.Key)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.Enter:
                        return;
                }
            }
        }
        static int Choice()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.Write("__________________________\n" +
                          "|                        |\n" +
                          "| 1-Пополнить баланс     |\n" +
                          "| 2-Сесть в втобус       |\n" +
                          "| 3-Выйти с автобуса     |\n" +
                          "| 4-Проехать на автобусе |\n" +
                          "| 5-Посмотреть баланс    |\n" +
                          "| 6-Выход                |\n" +
                          "|________________________|");
            ConsoleKeyInfo info;

            while (true)
            {
                info = Console.ReadKey(true);

                switch (info.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return Constants.FIRST_CHOICE;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return Constants.SECOND_CHOICE;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return Constants.THIRD_CHOICE;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return Constants.FOURTH_CHOICE;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        return Constants.FIFTH_CHOICE;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        return Constants.SIXTH_CHOICE;
                }
            }
            }        
    }
}
