using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLPasring
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public bool isCapital { get; set; }
        public string CountryName { get; set; }

        public City()
        {
            Id = Guid.NewGuid();
        }
    }
}
