using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraBus
{
    public class Card
    {
        public double Cash { get; set; }
        public bool Preferential { get; set; }

        public void WithdrawMoney(double money)
        {
            if(money < Constants.NULL)
            {
                throw new ArgumentException();
            }
            if(Preferential == false)
            {
                Cash -= money;
            }
        }

        public void PutMoney(double money)
        {
            if (money < Constants.NULL)
            {
                throw new ArgumentException();
            }
            Cash += money;
        }
    }
}
