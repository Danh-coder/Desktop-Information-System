using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Information_System
{
    public class Teacher: Person
    {
        // Private attributes
        private double salary;
        private string[] subjects = new string[2];

        // Public methods
        public Teacher(string name, string phone, string email, double salary, string[] subjects)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Role = Role.TeachingStaff;
            this.salary = salary;
            this.subjects = subjects;
        }
        // Getter, setter methods
        public double Salary { get { return salary; } set {  salary = value; } }
        public string[] Subjects { get {  return subjects; } set {  subjects = value; } }

        public new void PrintInformation()
        {
            base.PrintInformation(); // Call the base class's PrintInformation method

            // Print additional information specific to Teacher
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Subjects taught:");
            foreach (string subject in Subjects)
            {
                Console.WriteLine("- " + subject);
            }
        }

    }
}
