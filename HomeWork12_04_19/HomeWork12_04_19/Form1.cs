using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork12_04_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "A-104-10";
            builder.InitialCatalog = "MyDB";
            builder.PersistSecurityInfo = true;
            builder.UserID = textBox1.Text;
            builder.Password = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(SqlException exception)
                {
                    MessageBox.Show("Connection failed", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
