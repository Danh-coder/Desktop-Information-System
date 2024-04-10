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
    public partial class StudentForm : UserControl
    {
        public StudentForm()
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
                string[] currentSubjects = { currentSubject1Input.Text, currentSubject2Input.Text };
                string[] previousSubjects = { previousSubject1Input.Text, previousSubject2Input.Text };
   
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

                // Validate current subjects
                foreach (string subject in currentSubjects)
                    if (string.IsNullOrWhiteSpace(subject))
                        throw new Exception("Current subject name cannot be empty!");
                    else if (!IsValidSubject(subject))
                        throw new Exception("Current subject name can only contain numbers and alphabets!");

                // Validate previous subjects
                foreach (string subject in previousSubjects)
                    if (string.IsNullOrWhiteSpace(subject))
                        throw new Exception("Previous subject name cannot be empty!");
                    else if (!IsValidSubject(subject))
                        throw new Exception("Previous subject name can only contain numbers and alphabets!");

                /////////////////////////////////////
                // Transfer validated data to backend
                Student student = new Student(name, phone, email, currentSubjects, previousSubjects);
                Controller.AddNewData(student);
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

        // Function to validate subject names
        private bool IsValidSubject(string subject)
        {
            // Regular expression pattern to match only alphabets and numbers
            string pattern = @"^[a-zA-Z0-9\s]+$";

            // Check if the subject matches the pattern
            return Regex.IsMatch(subject, pattern);
        }
    }
}
