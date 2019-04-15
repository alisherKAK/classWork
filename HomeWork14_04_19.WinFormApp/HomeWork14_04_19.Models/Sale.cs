using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14_04_19.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
