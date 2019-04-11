using System.Collections.Generic;

namespace Market.Models
{
    public class Trolley
    {
        public List<Product> Products { get; set; }

        public Trolley()
        {
            Products = new List<Product>();
        }
    }
}
