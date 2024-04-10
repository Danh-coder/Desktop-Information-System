using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Information_System
{
    public partial class ViewTeachingStaff : UserControl
    {
        private bool cellValueChangedError = false;
        private int[] cellValueErrorIndex;

        public ViewTeachingStaff()
        {
            InitializeComponent();
        }

        private void ViewTeachingStaff_Load(object sender, EventArgs e)
        {
            try
            {
                // Set cells border
                dataTable.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

                // Set auto-generated columns
                dataTable.AutoGenerateColumns = true;

                // Load data from database
                DataTable data = Controller.ViewByUserGroup(Role.TeachingStaff);

                if (data.Rows.Count <= 0)
                {
                    MessageBox.Show("No TeachingStaff found!", caption: "Result Not Found", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    return;
                }

                // The subjects-related columns are somehow ineditable by default
                // => Make it editable: Set the ReadOnly property of relevant columns to false
                int subject1ColumnIndex = data.Columns.IndexOf("Subject1");
                int subject2ColumnIndex = data.Columns.IndexOf("Subject2");
                data.Columns[subject1ColumnIndex].ReadOnly = false;
                data.Columns[subject2ColumnIndex].ReadOnly = false;

                // Hide irrelevant columns
                data.Columns["Status"].ColumnMapping = MappingType.Hidden;
                data.Columns["Role"].ColumnMapping = MappingType.Hidden;
                data.Columns["Hours"].ColumnMapping = MappingType.Hidden;
                data.Columns["Current_subject1"].ColumnMapping = MappingType.Hidden;
                data.Columns["Current_subject2"].ColumnMapping = MappingType.Hidden;
                data.Columns["Previous_subject1"].ColumnMapping = MappingType.Hidden;
                data.Columns["Previous_subject2"].ColumnMapping = MappingType.Hidden;

                // Optionally, you can remove the columns altogether if you don't need them
                // data.Columns.Remove("Status");
                // data.Columns.Remove("Role");

                // Bind data to the DataGridView component
                dataTable.DataSource = data;

                // Add CellValueChanged event handler to validate input when a cell's value changes
                dataTable.CellValueChanged += DataTable_CellValueChanged;
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

        private void DataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Handle user update
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the entire row's values
                    DataGridViewRow row = dataTable.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                    string name = row.Cells["Name"].Value.ToString();
                    string phone = row.Cells["Phone"].Value.ToString();
                    string email = row.Cells["Email"].Value.ToString();

                    // Retrieve TeachingStaff attributes
                    DataGridViewCell salaryInput = row.Cells["Salary"];
                    if (double.TryParse(salaryInput.Value.ToString(), out double salary))
                        // The input can be casted to the double data type
                        salary = double.Parse(salaryInput.Value.ToString());
                    else throw new Exception("Salary must be numeric, measured in dollars and cents! It should follow the format: ddd.cc.");
                    string subject1 = row.Cells["Subject1"].Value.ToString();
                    string subject2 = row.Cells["Subject2"].Value.ToString();

                    // Validate user input
                    ValidateTeachingStaffInput(name, phone, email, salary, subject1, subject2);

                    /////////////////////////////////////
                    // Transfer validated data to backend
                    Teacher teacher = new Teacher(name, phone, email, salary, new string[2] { subject1, subject2 });
                    teacher.Id = id;
                    Controller.Edit(teacher);

                    // Format the salary cells as described in the SRS
                    NumberFormatInfo setPrecision = new NumberFormatInfo();
                    setPrecision.NumberDecimalDigits = 2;
                    salaryInput.Value = Convert.ToDecimal(salary.ToString("N", setPrecision)); // ddd.cc

                    cellValueChangedError = false;

                    // Display update success message
                    MessageBox.Show("Update data successfully!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {   // Database errors
                MessageBox.Show("SQL Error: " + ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {   // Other errors
                MessageBox.Show(ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                cellValueChangedError = true;
                cellValueErrorIndex = new int[2] { e.RowIndex, e.ColumnIndex };
                MessageBox.Show(e.RowIndex.ToString() + ", " + e.ColumnIndex.ToString());
                MessageBox.Show(cellValueChangedError.ToString());

                // Set focus to the cell containing the invalid input
                BeginInvoke((Action)(() =>
                {
                    dataTable.CurrentCell = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataTable.BeginEdit(true);
                }));
            }
        }

        public void ValidateTeachingStaffInput(string name, string phone, string email, double salary, string subject1, string subject2)
        {
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
            if (salary < 0)
                throw new Exception("Salary must be non-negative values!");

            // Validate subjects
            string[] subjects = { subject1, subject2 };
            foreach (string subject in subjects)
            {
                if (string.IsNullOrWhiteSpace(subject))
                {
                    throw new Exception("Subject name cannot be empty!");
                }
                else if (!IsValidSubject(subject))
                {
                    throw new Exception("Subject name can only contain numbers and alphabets!");
                }
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

        private void DataTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cellValueChangedError)
            {
                // Set focus to the cell containing the invalid input
                BeginInvoke((Action)(() =>
                {
                    dataTable.CurrentCell = dataTable.Rows[cellValueErrorIndex[0]].Cells[cellValueErrorIndex[1]];
                    dataTable.BeginEdit(true);
                }));
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dataTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected row
                DataGridViewRow selectedRow = dataTable.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Call the Controller.Delete method
                    Controller.Delete(id);

                    // Remove the selected row from the DataGridView
                    dataTable.Rows.Remove(selectedRow);

                    // Display delete success message
                    MessageBox.Show("Delete data successfully!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
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
    }
}
