using HomeWork14_04_19.DataAccess;
using HomeWork14_04_19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork14_04_19.WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<string> tables;
            using (DbRepository repository = new DbRepository())
            {
                tables = repository.GetTables();
            }

            for(int i = 0; i < tables.Count; i++)
            {
                comboBox1.Items.Add(tables[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = comboBox1.SelectedItem as string;

            switch(tableName)
            {
                case "Buyers":
                    dataGridView1.Columns.Add("", "Id");
                    dataGridView1.Columns.Add("", "Name");
                    dataGridView1.Columns.Add("", "Surname");
                    using(TableDataService<Buyer> dataService = new TableDataService<Buyer>())
                    {
                        var buyers = dataService.GetAll();
                        foreach(Buyer buyer in buyers)
                        {
                            dataGridView1.Rows.Add(buyer.Id, buyer.Name, buyer.Surname);
                        }
                    }
                    break;
                case "Sales":
                    dataGridView1.Columns.Add("", "Id");
                    dataGridView1.Columns.Add("", "BuyerId");
                    dataGridView1.Columns.Add("", "SellerId");
                    dataGridView1.Columns.Add("", "TransactionAmount");
                    dataGridView1.Columns.Add("", "TransactionDate");
                    using (TableDataService<Sale> dataService = new TableDataService<Sale>())
                    {
                        var sales = dataService.GetAll();
                        foreach (Sale sale in sales)
                        {
                            dataGridView1.Rows.Add(sale.Id, sale.BuyerId, sale.SellerId, sale.TransactionAmount, sale.TransactionDate);
                        }
                    }
                    break;
                case "Sellers":
                    dataGridView1.Columns.Add("", "Id");
                    dataGridView1.Columns.Add("", "Name");
                    dataGridView1.Columns.Add("", "Surname");
                    using (TableDataService<Seller> dataService = new TableDataService<Seller>())
                    {
                        var sellers = dataService.GetAll();
                        foreach (Seller seller in sellers)
                        {
                            dataGridView1.Rows.Add(seller.Id, seller.Name, seller.Surname);
                        }
                    }
                    break;
            }
        }
    }
}
