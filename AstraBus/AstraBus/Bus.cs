using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraBus
{
    public class Bus
    {
        private int _busNumber;
        public int BusNumber
        {
            get
            {
                return _busNumber;
            }
            set
            {
                if (value >= Constants.FIRST_CITY_BUS && value <= Constants.LAST_CITY_BUS)
                {
                    _busNumber = value;
                    ChildrenTicketPrice = Constants.CITY_BUS_CHILDREN_TICKET_PRICE;
                    AdultTicketPrice = Constants.CITY_BUS_ADULT_TICKET_PRICE;
                }
                else if (value >= Constants.FIRST_EXPRESS_BUS && value <= Constants.LAST_EXPRESS_BUS)
                {
                    _busNumber = value;
                    ChildrenTicketPrice = Constants.EXPRESS_BUS_CHILDREN_TICKET_PRICE;
                    AdultTicketPrice = Constants.EXPRESS_BUS_ADULT_TICKET_PRICE;
                }
                else if (value >= Constants.FIRST_SUBURBAN_BUS && value <= Constants.LAST_SUBURBAN_BUS)
                {
                    _busNumber = value;
                    ChildrenTicketPrice = Constants.SUBURBAN_BUS_CHILDREN_TICKET_PRICE;
                    AdultTicketPrice = Constants.SUBURBAN_BUS_ADULT_TICKET_PRICE;
                }
                else
                {
                    throw new ArgumentException("Такого автобуса нет!");
                }
            }
        }
        public int ChildrenTicketPrice { get; set; }
        public int AdultTicketPrice { get; set; }

        public Bus() { }
        public Bus(int busNumber)
        {
            BusNumber = busNumber;
        }
    }
}
