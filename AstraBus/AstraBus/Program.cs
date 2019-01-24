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
                        SitOnBus(bus, isSited);
                        break;
                    case Constants.THIRD_CHOICE:
                        break;
                    case Constants.FOURTH_CHOICE:
                        RideOnBus(bus, card, isSited);
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
                    break;
                }
            }
        }
        static void GetOffTheBus(bool isSited)
        {
            Console.Write("Вы вышли с автобуса");
            Console.ReadKey(true);
        }
        static void RideOnBus(Bus bus, Card card, bool isSited)
        {
            if(isSited == true)
            {
                if(card.Preferential == false)
                {
                    Console.Write("Вы плтите детский или взрослый билет(c\a): ");

                    while (true)
                    {
                        string choice = Console.ReadLine();

                        if (choice == "c" || choice == "C" || choice == "Child" || choice == "CHILD")
                        {
                            if(card.Cash >= bus.ChildrenTicketPrice)
                            {
                                card.WithdrawMoney(bus.ChildrenTicketPrice);
                                Console.Write("Все хорошо можете ездить");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.Write("Вам не хвотает денег!");
                                Console.ReadKey(true);
                                isSited = false;
                            }
                        }
                        else if(choice == "a" || choice == "A" || choice == "Adult" || choice == "ADULT")
                        {
                            if (card.Cash >= bus.AdultTicketPrice)
                            {
                                card.WithdrawMoney(bus.AdultTicketPrice);
                                Console.Write("Все хорошо можете ездить");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.Write("Вам не хвотает денег!");
                                Console.ReadKey(true);
                                isSited = false;
                            }
                        }
                    }
                  
                }
                else
                {
                    Console.Write("Вы проехали какоето расстояние");
                }
            }
            else
            {
                Console.Write("Вы не сели в автобус");
            }
        }
        static void SitOnBus(Bus bus, bool isSited)
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Write("На какой автобус вы хотите сесть( 1~99 внутри города, 100~199 экспресс внутр города, 300~399 пригородные ): ");

                    int busNumber = Constants.NULL;

                    if (int.TryParse(Console.ReadLine(), out busNumber))
                    {
                        bus.BusNumber = busNumber;
                        isSited = true;
                        return;
                    }

                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }
        static void TopUpBalance(Card card)
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Вы относитесь к льготной группе(y/n): ");

                string choice = Console.ReadLine();

                if(choice == "y" || choice == "Y" || choice == "Yes" || choice == "yes" || choice == "YES")
                {
                    card.Preferential = true;
                    break;
                }
                else if (choice == "n" || choice == "N" || choice == "No" || choice == "no" || choice == "NO")
                {
                    card.Preferential = false;
                    break;
                }
            }

            if(card.Preferential == true)
            {
                Console.Write("Вам бесплано на все автобусы!");
                Console.Read();
            }
            else
            {
                Console.Write("На какую сумму вы хотите поплнить карту: ");

                while (true)
                {
                    double sum = Constants.NULL;

                    if(double.TryParse(Console.ReadLine(), out sum))
                    {
                        card.PutMoney(sum);
                        break;
                    }
                    else
                    {

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
