using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Information_System
{
    public partial class AdminstrationForm : UserControl
    {
        public AdminstrationForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user inputs at UI
                string name = nameInput.Text;
                string phone = telephoneInput.Text;
                string email = emailInput.Text;
                double salary;
                string status = statusInput.SelectedItem.ToString();
                int hours;

                    // Validate name
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("Name cannot be empty!");
                if (Regex.IsMatch(name, @"[^a-zA-Z\s]"))
                    throw new Exception("Name can only contain alphabets and whitespace!");

                // Validate phone number
                if (string.IsNullOrWhiteSpace(phone))
                    throw new Exception("Telephone number cannot be empty!");
                if (!Regex.IsMatch(phone, @"^\(\+84\) \d{3}-\d{3}-\d{3}$"))
                    throw new Exception("Invalid telephone number format! It should be like (+84) xxx-xxx-xxx.");

                    // Validate email
                if (string.IsNullOrWhiteSpace(email) || !IsEmailValid(email))
                    throw new Exception("Invalid email address!");

                    // Validate salary
                if (double.TryParse(salaryInput.Text, out salary))
                    salary = double.Parse(salaryInput.Text);
                else throw new Exception("Salary must be numeric, measured in dollars and cents! It should follow the format: ddd.cc.");
                if (salary < 0)
                    throw new Exception("Salary must be non-negative values!");

                    // Validate working hours
                if (int.TryParse(hoursInput.Text, out hours))
                    hours = int.Parse(hoursInput.Text);
                else throw new Exception("Working hours must be numeric!");
                if (hours < 0)
                    throw new Exception("Working hours must be non-negative values!");

                /////////////////////////////////////
                // Transfer validated data to backend
                Admin admin = new Admin(name, phone, email, salary, status, hours);
                Controller.AddNewData(admin);
                MessageBox.Show("Add data successfully!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {   // Database errors
                MessageBox.Show("SQL Error: " + ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {   // Other errors
                MessageBox.Show(ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        // Function to validate email address
        static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
