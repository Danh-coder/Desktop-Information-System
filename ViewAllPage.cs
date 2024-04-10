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
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop_Information_System
{
    public partial class ViewAllPage : UserControl
    {
        private bool cellValueChangedError = false;
        private int[] cellValueErrorIndex;
        private bool isFirstBinding = true;

        public ViewAllPage()
        {
            InitializeComponent();
        }

        private void ViewAllPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Set cells border
                dataTable.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

                // Set auto-generated columns
                dataTable.AutoGenerateColumns = true;

                // Load data from database
                DataTable data = Controller.ViewAll();

                if (data.Rows.Count <= 0)
                {
                    MessageBox.Show("No record found!", caption: "Result Not Found", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    return;
                }

                // The subjects-related columns are somehow ineditable by default
                // => Make it editable: Set the ReadOnly property of relevant columns to false
                int subject1ColumnIndex = data.Columns.IndexOf("Subject1");
                int subject2ColumnIndex = data.Columns.IndexOf("Subject2");
                int currentSubject1ColumnIndex = data.Columns.IndexOf("Current_subject1");
                int currentSubject2ColumnIndex = data.Columns.IndexOf("Current_subject2");
                int previousSubject1ColumnIndex = data.Columns.IndexOf("Previous_subject1");
                int previousSubject2ColumnIndex = data.Columns.IndexOf("Previous_subject2");
                data.Columns[subject1ColumnIndex].ReadOnly = false;
                data.Columns[subject2ColumnIndex].ReadOnly = false;
                data.Columns[currentSubject1ColumnIndex].ReadOnly = false;
                data.Columns[currentSubject2ColumnIndex].ReadOnly = false;
                data.Columns[previousSubject1ColumnIndex].ReadOnly = false;
                data.Columns[previousSubject2ColumnIndex].ReadOnly = false;

                // Bind data to the DataGridView component
                dataTable.DataSource = data;

                // Add ComboBox column for the status column
                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.Name = "Status";
                statusColumn.HeaderText = "Status";
                statusColumn.DataPropertyName = "Status"; // Name of the data source column
                statusColumn.Items.AddRange("Full-time", "Part-time", "N/A"); // Add ComboBox items

                // Set the appropriate default value for each cell based on the data
                foreach (DataGridViewRow row in dataTable.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Full-time")
                        row.Cells["Status"].Value = "Full-time";
                    else if (status == "Part-time")
                        row.Cells["Status"].Value = "Part-time";
                    else row.Cells["Status"].Value = "N/A";
                }

                // Remove existing status column
                dataTable.Columns.Remove("Status");

                // Insert ComboBox column at index 8
                dataTable.Columns.Insert(8, statusColumn);

                // Handler when data is completely binded to the DataGridView
                dataTable.DataBindingComplete += DataTable_DataBindingComplete;

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

        private void DataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Handle on the first data binding
            if (!isFirstBinding) return;
            isFirstBinding = false;

            // Loop through each cell in the DataGridView
            foreach (DataGridViewRow row in dataTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check if the cell value is "N/A", an Id, or a Role
                    if (cell.Value == null || cell.Value.ToString() == "N/A" || cell.Value.ToString() == "" || cell.ColumnIndex == 4 || cell.ColumnIndex == 0)
                    {
                        // Style the cell as disabled input
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = SystemColors.GrayText;
                        cell.Style.SelectionForeColor = SystemColors.GrayText;
                        cell.ReadOnly = true;

                        // For ComboBox columns (e.g. status) which values are N/A, set them to display as disabled ComboBoxes
                        if (dataTable.Columns[cell.ColumnIndex] is DataGridViewComboBoxColumn)
                        {
                            DataGridViewComboBoxCell comboBoxCell = cell as DataGridViewComboBoxCell;
                            comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        }
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Black;
                        cell.Style.BackColor = Color.White;
                        cell.Style.SelectionForeColor = Color.Black;
                        cell.ReadOnly = false;

                        // For ComboBox columns (e.g. status), set them to display as normal ComboBoxes
                        if (dataTable.Columns[cell.ColumnIndex] is DataGridViewComboBoxColumn)
                        {
                            DataGridViewComboBoxCell comboBoxCell = cell as DataGridViewComboBoxCell;
                            comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                        }
                    }
                }
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
                    string role = row.Cells["Role"].Value.ToString();
                    if (role == "TeachingStaff")
                    {
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
                        Teacher teacher = new Teacher(name, phone, email, salary, new string[2] {subject1, subject2});
                        teacher.Id = id;
                        Controller.Edit(teacher);

                        // Format the salary cells as described in the SRS
                        NumberFormatInfo setPrecision = new NumberFormatInfo();
                        setPrecision.NumberDecimalDigits = 2;
                        salaryInput.Value = Convert.ToDecimal(salary.ToString("N", setPrecision)); // ddd.cc
                    }
                    if (role == "Administration")
                    {
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
                    }
                    if (role == "Student")
                    {
                        // Retrieve Student attributes
                        string currentSubject1 = row.Cells["Current_Subject1"].Value.ToString();
                        string currentSubject2 = row.Cells["Current_Subject2"].Value.ToString();
                        string previousSubject1 = row.Cells["Previous_Subject1"].Value.ToString();
                        string previousSubject2 = row.Cells["Previous_Subject2"].Value.ToString();

                        // Validate user input
                        ValidateStudentInput(name, phone, email, currentSubject1, currentSubject2, previousSubject1, previousSubject2);

                        /////////////////////////////////////
                        // Transfer validated data to backend
                        Student student = new Student(name, phone, email, new string[2] {currentSubject1, currentSubject2}, new string[2] { previousSubject1, previousSubject2 });
                        student.Id = id;
                        Controller.Edit(student);
                    }

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

        public void ValidateStudentInput(string name, string phone, string email, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
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

            // Validate current subjects
            string[] currentSubjects = { currentSubject1, currentSubject2 };
            foreach (string subject in currentSubjects)
                if (string.IsNullOrWhiteSpace(subject))
                    throw new Exception("Current subject name cannot be empty!");
                else if (!IsValidSubject(subject))
                    throw new Exception("Current subject name can only contain numbers and alphabets!");

            // Validate previous subjects
            string[] previousSubjects = { previousSubject1, previousSubject2 };
            foreach (string subject in previousSubjects)
                if (string.IsNullOrWhiteSpace(subject))
                    throw new Exception("Previous subject name cannot be empty!");
                else if (!IsValidSubject(subject))
                    throw new Exception("Previous subject name can only contain numbers and alphabets!");
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
