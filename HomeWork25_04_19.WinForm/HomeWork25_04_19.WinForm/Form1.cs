using HomeWork25_04_19.DataAccess;
using HomeWork25_04_19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork25_04_19.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Login", "Login");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("PhoneNumber", "PhoneNumber");
            dataGridView1.Columns.Add("IsAdmin", "IsAdmin");

            using (TableDataService<User> dataService = new TableDataService<User>())
            {
                var users = dataService.GetAll();

                List<string> usersLogin = new List<string>();

                for(int i = 0; i < users.Count; i++)
                {
                    usersLogin.Add(users[i].Login);
                }

                listBox1.DataSource = usersLogin;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.Show();
            //listBox1.DataSource = 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = listBox1.SelectedIndex;

            if (selectedItemIndex >= 0)
            {
                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var dataSet = new DataSet("ShopDb");
                    var dataAdapter = dataService.GetDataAdapter();

                    dataAdapter.Fill(dataSet, "Users");

                    var usersTable = dataSet.Tables["Users"];

                    var row = usersTable.Rows[selectedItemIndex];
                    row.BeginEdit();
                    row.Delete();
                    row.EndEdit();

                    dataAdapter.Update(dataSet, "Users");

                    listBox1.Items.RemoveAt(selectedItemIndex);
                    dataGridView1.Rows.Clear();
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = listBox1.SelectedIndex;

            if (selectedItemIndex >= 0)
            {
                dataGridView1.Rows.Clear();

                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var users = dataService.GetAll();

                    dataGridView1.Rows.Add(users[selectedItemIndex].Id, users[selectedItemIndex].Login, users[selectedItemIndex].Password, users[selectedItemIndex].Address, users[selectedItemIndex].PhoneNumber, users[selectedItemIndex].IsAdmin);
                }
            }
        }
    }
}
