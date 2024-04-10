using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Information_System
{
    public class Admin: Person
    {
        // Private attributes
        private double salary;
        private string status;
        private int hours;

        // Public methods
        public Admin(string name, string phone, string email, double salary, string status, int hours)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Role = Role.Administration;
            this.salary = salary;
            this.status = status;
            this.hours = hours;
        }
        // Getter, setter methods
        public double Salary { get { return salary; } set {  salary = value; } }
        public string Status { get { return status; } set { status = value; } }
        public int Hours { get { return hours; } set { hours = value; } }

        public new void PrintInformation()
        {
            base.PrintInformation(); // Call the base class's PrintInformation method

            // Print additional information specific to Admin
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Hours: " + Hours);
        }
    }
}
