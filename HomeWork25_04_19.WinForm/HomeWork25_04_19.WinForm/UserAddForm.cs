using HomeWork25_04_19.DataAccess;
using HomeWork25_04_19.Models;
using HomeWork25_04_19.Sevices;
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
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User newUser = new User();

                if(CheckData.IsLoginCorrect(textBox1.Text))
                {
                    newUser.Login = textBox1.Text;
                }
                else
                {
                    throw new ArgumentException("Логин был введен неверно");
                }

                if(CheckData.IsPasswordCorrect(textBox2.Text))
                {
                    newUser.Password = textBox2.Text;
                }
                else
                {
                    throw new ArgumentException("Пароль был введен неверно");
                }

                if (CheckData.IsPhoneNumberCorrect(textBox4.Text))
                {
                    newUser.PhoneNumber = textBox4.Text;
                }
                else
                {
                    throw new ArgumentException("Номер телефона был введен неверно");
                }

                newUser.IsAdmin = checkBox1.Checked;
                newUser.Address = textBox3.Text;

                using(TableDataService<User> dataService = new TableDataService<User>())
                {
                    dataService.Add(newUser);
                    this.Close();
                }
            }
            catch(ArgumentException exception)
            {
                MessageBox.Show(this, exception.Message, "Error");
            }
        }
    }
}
