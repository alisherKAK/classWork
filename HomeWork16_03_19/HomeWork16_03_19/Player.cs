using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_03_19
{
    public class Player
    {
        public string Nickname { get; set; }
        public List<Card> Cards { get; set; }

        public void ShowCards()
        {
            Console.WriteLine($"{Nickname}'s cards:");
            Console.WriteLine("====================");
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.Type.ToString()} {card.Lear.ToString()}");
            }
            Console.WriteLine("====================");
        }
    }
}
