using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HomeWork26_04_19.Models;

namespace HomeWork26_04_19.DataAccess
{
    public class StockContext : DbContext
    {
        public StockContext() : base("StockDb")
        {}

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
