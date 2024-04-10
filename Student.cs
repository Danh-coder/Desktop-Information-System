using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Information_System
{
    public class Student: Person
    {
        // Private attributes
        private string[] currentSubjects = new string[2];
        private string[] previousSubjects = new string[2];

        // Public methods
        public Student(string name, string phone, string email, string[] currentSubjects, string[] previousSubjects)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Role = Role.Student;
            this.currentSubjects = currentSubjects;
            this.previousSubjects = previousSubjects;
        }
        // Getter, setter methods
        public string[] CurrentSubjects { get { return currentSubjects; } set { currentSubjects = value; } }
        public string[] PreviousSubjects { get { return previousSubjects; } set {  previousSubjects = value; } }

        public new void PrintInformation()
        {
            base.PrintInformation(); // Call the base class's PrintInformation method

            // Print additional information specific to Student
            Console.WriteLine("Current Subjects:");
            foreach (string subject in CurrentSubjects)
            {
                Console.WriteLine("- " + subject);
            }
            Console.WriteLine("Previous Subjects:");
            foreach (string subject in PreviousSubjects)
            {
                Console.WriteLine("- " + subject);
            }
        }
    }
}
