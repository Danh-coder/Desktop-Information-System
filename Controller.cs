using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Xml.Linq;

namespace Desktop_Information_System
{
    static class Controller
    {
        // Private attributes
        // Connection string for SQL Server
        private static string connectionString = "Data Source=DANH-LAPTOP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        // Public methods
        // Public method to initialize the application
        public static void Init()
        {
            // Check if the connection string is valid
            if (!IsConnectionStringValid(connectionString))
            {
                // If connection string is invalid, inform the user and exit the application
                MessageBox.Show("Invalid connection string. Please provide a valid connection string in the Controller class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); // Exit the application with an error code
            }

            // Create the database if it doesn't exist
            CreateDatabaseIfNotExists();

            // Set the connection string to use the DIS database
            connectionString = "Data Source=DANH-LAPTOP\\SQLEXPRESS;Initial Catalog=DIS;Integrated Security=True";

            // Create the table within the DIS database
            CreateTable();
        }

        // Method to check if the connection string is valid
        private static bool IsConnectionStringValid(string connectionString)
        {
            try
            {
                // Try to open a connection using the provided connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                return true; // Connection string is valid
            }
            catch (Exception)
            {
                return false; // Connection string is invalid
            }
        }

        // Private method to create the database if it doesn't exist
        private static void CreateDatabaseIfNotExists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to check if the database exists
                string sqlCheckDatabase = "SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = 'DIS'";

                // SQL command to create the database
                string sqlCreateDatabase = "CREATE DATABASE DIS";

                // Create SQL command objects
                SqlCommand commandCheckDatabase = new SqlCommand(sqlCheckDatabase, connection);
                SqlCommand commandCreateDatabase = new SqlCommand(sqlCreateDatabase, connection);

                connection.Open();

                // Check if the database exists
                int databaseCount = (int)commandCheckDatabase.ExecuteScalar();

                if (databaseCount == 0)
                {
                    // Database doesn't exist, so create it
                    commandCreateDatabase.ExecuteNonQuery();
                }
            }
        }

        // Private method to create the table within the DIS database
        private static void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to check if the table exists
                string sqlCheckTable = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'users'";

                // Create SQL command object
                SqlCommand commandCheckTable = new SqlCommand(sqlCheckTable, connection);

                connection.Open();

                // Execute the command to check if the table exists
                int tableCount = (int)commandCheckTable.ExecuteScalar();

                if (tableCount == 0)
                {
                    // Table does not exist, create it
                    // SQL command to create the table
                    string sqlCreateTable = @"
                CREATE TABLE users (
                    id INT PRIMARY KEY IDENTITY(1,1),
                    name NVARCHAR(255) NOT NULL,
                    phone VARCHAR(17) NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    role VARCHAR(20) NOT NULL,
                    salary DECIMAL(10, 2),
                    subjects NVARCHAR(255),
                    status VARCHAR(20),
                    hours INT,
                    current_subjects NVARCHAR(255),
                    previous_subjects NVARCHAR(255),
                    CONSTRAINT UC_Email UNIQUE (email)
                )";

                    // Create SQL command object
                    SqlCommand commandCreateTable = new SqlCommand(sqlCreateTable, connection);

                    // Execute the command to create the table
                    commandCreateTable.ExecuteNonQuery();
                }
            }
        }


        public static void AddNewData(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to insert data
                string sql = "INSERT INTO users (name, phone, email, role, salary, subjects, status, hours, current_subjects, previous_subjects) " +
                                "VALUES (@Name, @Phone, @Email, @Role, @Salary, @Subjects, @Status, @Hours, @CurrentSubjects, @PreviousSubjects)";

                // Create SQL command object
                SqlCommand command = new SqlCommand(sql, connection);

                // Prepare parameters
                string name = person.Name;
                string phone = person.Phone;
                string email = person.Email;
                string role = person.Role.ToString();
                // Some variables depend on user roles so they can be null
                double? salary = null;
                string subjects = null;
                string status = null;
                int? hours = null;
                string currentSubjects = null;
                string previousSubjects = null;

                if (person is Teacher)
                {
                    Teacher teacher = (Teacher)person;
                    salary = teacher.Salary;
                    subjects = teacher.Subjects[0] + ',' + teacher.Subjects[1];
                }
                if (person is Admin)
                {
                    Admin admin = (Admin)person;
                    salary = admin.Salary;
                    status = admin.Status;
                    hours = admin.Hours;
                }
                if (person is Student)
                {
                    Student student = (Student)person;
                    currentSubjects = student.CurrentSubjects[0] + ',' + student.CurrentSubjects[1];
                    previousSubjects = student.PreviousSubjects[0] + ',' + student.PreviousSubjects[1];
                }

                // Add parameters
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@Salary", salary ?? (object)DBNull.Value); // It can be null
                command.Parameters.AddWithValue("@Subjects", subjects ?? (object)DBNull.Value); // It can be null
                command.Parameters.AddWithValue("@Status", status ?? (object)DBNull.Value); // It can be null
                command.Parameters.AddWithValue("@Hours", hours ?? (object)DBNull.Value); // It can be null
                command.Parameters.AddWithValue("@CurrentSubjects", currentSubjects ?? (object)DBNull.Value); // It can be null
                command.Parameters.AddWithValue("@PreviousSubjects", previousSubjects ?? (object)DBNull.Value); // It can be null

                // Execute the command
                command.ExecuteNonQuery();
            }
        }

        public static DataTable ViewAll()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to select all data
                string sql = "SELECT id, name, phone, email, role, salary, " +
                             "SUBSTRING(subjects, 1, CHARINDEX(',', subjects + ',') - 1) AS subject1, " +
                             "SUBSTRING(subjects, CHARINDEX(',', subjects + ',') + 1, LEN(subjects) - CHARINDEX(',', subjects + ',') + 1) AS subject2, " +
                             "status, hours, " +
                             "SUBSTRING(current_subjects, 1, CHARINDEX(',', current_subjects + ',') - 1) AS current_subject1, " +
                             "SUBSTRING(current_subjects, CHARINDEX(',', current_subjects + ',') + 1, LEN(current_subjects) - CHARINDEX(',', current_subjects + ',') + 1) AS current_subject2, " +
                             "SUBSTRING(previous_subjects, 1, CHARINDEX(',', previous_subjects + ',') - 1) AS previous_subject1, " +
                             "SUBSTRING(previous_subjects, CHARINDEX(',', previous_subjects + ',') + 1, LEN(previous_subjects) - CHARINDEX(',', previous_subjects + ',') + 1) AS previous_subject2 " +
                             "FROM users";

                // Create SQL command object
                SqlCommand command = new SqlCommand(sql, connection);

                // Execute the command and read data into a DataTable
                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            // Change column headers to capitalize only the first letter
            foreach (DataColumn column in dataTable.Columns)
            {
                column.ColumnName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(column.ColumnName.ToLower());
            }

            return dataTable;
        }

        // Add other methods like ViewByUserGroup, Edit, Delete, etc.
        public static DataTable ViewByUserGroup(Role role)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to select all data
                string sql = "SELECT id, name, phone, email, role, salary, " +
                             "SUBSTRING(subjects, 1, CHARINDEX(',', subjects + ',') - 1) AS subject1, " +
                             "SUBSTRING(subjects, CHARINDEX(',', subjects + ',') + 1, LEN(subjects) - CHARINDEX(',', subjects + ',') + 1) AS subject2, " +
                             "status, hours, " +
                             "SUBSTRING(current_subjects, 1, CHARINDEX(',', current_subjects + ',') - 1) AS current_subject1, " +
                             "SUBSTRING(current_subjects, CHARINDEX(',', current_subjects + ',') + 1, LEN(current_subjects) - CHARINDEX(',', current_subjects + ',') + 1) AS current_subject2, " +
                             "SUBSTRING(previous_subjects, 1, CHARINDEX(',', previous_subjects + ',') - 1) AS previous_subject1, " +
                             "SUBSTRING(previous_subjects, CHARINDEX(',', previous_subjects + ',') + 1, LEN(previous_subjects) - CHARINDEX(',', previous_subjects + ',') + 1) AS previous_subject2 " +
                             "FROM users " +
                             "WHERE role = @Role";

                // Create SQL command object
                SqlCommand command = new SqlCommand(sql, connection);

                // Add parameters
                command.Parameters.AddWithValue("@Role", role.ToString());

                // Execute the command and read data into a DataTable
                SqlDataReader reader = command.ExecuteReader();

                // Check if the reader has rows
                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                    // Change column headers to capitalize only the first letter
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ColumnName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(column.ColumnName.ToLower());
                    }
                }

                // Close the reader
                reader.Close();
            }

            return dataTable;
        }

        public static void Edit(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to update data
                string sql = "UPDATE users SET name = @Name, phone = @Phone, email = @Email, role = @Role, " +
                             "salary = @Salary, subjects = @Subjects, status = @Status, hours = @Hours, " +
                             "current_subjects = @CurrentSubjects, previous_subjects = @PreviousSubjects " +
                             "WHERE id = @Id";

                // Create SQL command object
                SqlCommand command = new SqlCommand(sql, connection);

                string name = person.Name;
                string phone = person.Phone;
                string email = person.Email;
                string role = person.Role.ToString();
                double? salary = null;
                string subjects = null;
                string status = null;
                int? hours = null;
                string currentSubjects = null;
                string previousSubjects = null;

                if (person is Teacher)
                {
                    Teacher teacher = (Teacher)person;
                    salary = teacher.Salary;
                    subjects = teacher.Subjects[0] + ',' + teacher.Subjects[1];
                }
                if (person is Admin)
                {
                    Admin admin = (Admin)person;
                    salary = admin.Salary;
                    status = admin.Status;
                    hours = admin.Hours;
                }
                if (person is Student)
                {
                    Student student = (Student)person;
                    currentSubjects = student.CurrentSubjects[0] + ',' + student.CurrentSubjects[1];
                    previousSubjects = student.PreviousSubjects[0] + ',' + student.PreviousSubjects[1];
                }

                // Add parameters
                command.Parameters.AddWithValue("@Id", person.Id);  // Match the ID
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@Salary", salary ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Subjects", subjects ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Status", status ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Hours", hours ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CurrentSubjects", currentSubjects ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PreviousSubjects", previousSubjects ?? (object)DBNull.Value);

                // Execute the command
                command.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to delete data based on ID
                string sql = "DELETE FROM users WHERE id = @Id";

                // Create SQL command object
                SqlCommand command = new SqlCommand(sql, connection);

                // Add parameter for ID
                command.Parameters.AddWithValue("@Id", id);

                // Execute the command
                command.ExecuteNonQuery();
            }
        }
    }
}