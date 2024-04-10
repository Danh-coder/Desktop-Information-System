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
    public partial class ViewAdministration : UserControl
    {
        private bool cellValueChangedError = false;
        private int[] cellValueErrorIndex;

        public ViewAdministration()
        {
            InitializeComponent();
        }

        private void ViewAdministration_Load(object sender, EventArgs e)
        {
            try
            {
                // Set cells border
                dataTable.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

                // Set auto-generated columns
                dataTable.AutoGenerateColumns = true;

                // Load data from database
                DataTable data = Controller.ViewByUserGroup(Role.Administration);

                if (data.Rows.Count <= 0) {
                    MessageBox.Show("No Administration found!", caption: "Result Not Found", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    return; 
                }

                // Hide irrelevant columns
                data.Columns["Role"].ColumnMapping = MappingType.Hidden;
                data.Columns["Subject1"].ColumnMapping = MappingType.Hidden;
                data.Columns["Subject2"].ColumnMapping = MappingType.Hidden;
                data.Columns["Current_subject1"].ColumnMapping = MappingType.Hidden;
                data.Columns["Current_subject2"].ColumnMapping = MappingType.Hidden;
                data.Columns["Previous_subject1"].ColumnMapping = MappingType.Hidden;
                data.Columns["Previous_subject2"].ColumnMapping = MappingType.Hidden;

                // Optionally, you can remove the columns altogether if you don't need them
                // data.Columns.Remove("Status");
                // data.Columns.Remove("Role");

                // Bind data to the DataGridView component
                dataTable.DataSource = data;

                // Add ComboBox column for the status column
                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.Name = "Status";
                statusColumn.HeaderText = "Status";
                statusColumn.DataPropertyName = "Status"; // Name of the data source column
                statusColumn.Items.AddRange("Full-time", "Part-time"); // Add ComboBox items

                // Set the appropriate default value for each cell based on the data
                foreach (DataGridViewRow row in dataTable.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Full-time")
                        row.Cells["Status"].Value = "Full-time";
                    else if (status == "Part-time")
                        row.Cells["Status"].Value = "Part-time";
                }

                // Remove existing status column
                dataTable.Columns.Remove("Status");

                // Insert ComboBox column at index 6
                dataTable.Columns.Insert(6, statusColumn);

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
                    // Retrieve Adminstration attributes
                    string status = row.Cells["Status"].Value.ToString();
                    if (string.IsNullOrEmpty(status))
                        throw new Exception("Status must not be empty! Choose another value!");

                    DataGridViewCell salaryInput = row.Cells["Salary"];
                    if (double.TryParse(salaryInput.Value.ToString(), out double salary))
                        // The input can be casted to the double data type
                        salary = double.Parse(salaryInput.Value.ToString());
                    else throw new Exception("Salary must be numeric, measured in dollars and cents! It should follow the format: ddd.cc.");

                    DataGridViewCell hoursInput = row.Cells["Hours"];
                    if (int.TryParse(hoursInput.Value.ToString(), out int hours))
                        // The input can be casted to the int data type
                        hours = int.Parse(hoursInput.Value.ToString());
                    else throw new Exception("Working hours must be numeric!");

                    // Validate user input
                    ValidateAdministrationInput(name, phone, email, salary, status, hours);

                    /////////////////////////////////////
                    // Transfer validated data to backend
                    Admin admin = new Admin(name, phone, email, salary, status, hours);
                    admin.Id = id;
                    Controller.Edit(admin);

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

                // Set focus to the cell containing the invalid input
                BeginInvoke((Action)(() =>
                {
                    dataTable.CurrentCell = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataTable.BeginEdit(true);
                }));
            }
        }

        public void ValidateAdministrationInput(string name, string phone, string email, double salary, string status, int hours)
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
                throw new Exception("Invalid telephone number format! \n It should be like (+84) xxx-xxx-xxx.");

            // Validate email
            if (string.IsNullOrWhiteSpace(email) || !IsEmailValid(email))
                throw new Exception("Invalid email address!");

            // Validate salary
            if (salary < 0)
                throw new Exception("Salary must be non-negative values!");

            // Validate working hours
            if (hours < 0)
                throw new Exception("Working hours must be non-negative values!");
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
