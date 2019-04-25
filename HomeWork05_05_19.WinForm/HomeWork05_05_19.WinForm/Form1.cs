using HomeWork05_05_19.DataAccess;
using HomeWork05_05_19.Models;
using HomeWork05_05_19.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork05_05_19.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new CityPhoneNumberContext())
            {
                foreach (var city in context.Cities.ToList())
                {
                    CitiesComboBox.Items.Add(city.Name);
                }
            }
        }

        private void CitiesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedCity = CitiesComboBox.SelectedItem.ToString();

            using(var context = new CityPhoneNumberContext())
            {
                CityPhoneCodeLabel.Text = context.Cities.Where(city => city.Name == selectedCity).SingleOrDefault().CityPhoneCode;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string selectedCity = CitiesComboBox.SelectedItem?.ToString();

            if (selectedCity != null)
            {
                if (CheckSetInformation.CheckCityPhoneNumber(UserPhoneNumberTextBox.Text.Trim()))
                {
                    if (CheckSetInformation.CheckUsername(UsernameTextBox.Text.Trim()))
                    {
                        using (var context = new CityPhoneNumberContext())
                        {
                            CityPhoneNumber newCityPhoneNumber = new CityPhoneNumber()
                            {
                                Number = context.Cities.Where(city => city.Name == selectedCity).SingleOrDefault().CityPhoneCode + UserPhoneNumberTextBox.Text.Trim(),
                                Username = UsernameTextBox.Text.Trim(),
                                City = context.Cities.Where(city => city.Name == selectedCity).SingleOrDefault()
                            };

                            context.CityPhoneNumbers.Add(newCityPhoneNumber);
                            context.SaveChanges();

                            UserPhoneNumberTextBox.Text = string.Empty;
                            UsernameTextBox.Text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Номер телефона был введен неверно", "Phone Number Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Номер телефона был введен неверно", "Phone Number Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(this, "Выберите город", "Select City Error", MessageBoxButtons.OK);
            }
        }
    }
}
