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
                if (_busNumber >= Constants.FIRST_CITY_BUS && _busNumber <= Constants.LAST_CITY_BUS)
                {
                    ChildrenTicketPrice = Constants.CITY_BUS_CHILDREN_TICKET_PRICE;
                    AdultTicketPrice = Constants.CITY_BUS_ADULT_TICKET_PRICE;
                }
                else if (_busNumber >= Constants.FIRST_EXPRESS_BUS && _busNumber <= Constants.LAST_EXPRESS_BUS)
                {
                    ChildrenTicketPrice = Constants.EXPRESS_BUS_CHILDREN_TICKET_PRICE;
                    AdultTicketPrice = Constants.EXPRESS_BUS_ADULT_TICKET_PRICE;
                }
                else if (_busNumber >= Constants.FIRST_SUBURBAN_BUS && _busNumber <= Constants.LAST_SUBURBAN_BUS)
                {
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
