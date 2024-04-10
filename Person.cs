using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Information_System
{
    public enum Role
    {
        TeachingStaff,
        Administration,
        Student
    }

    public class Person
    {
        // Private attributes
        private int id;
        private string name;
        private string phone;
        private string email;
        private Role role;

        // Public methods
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set {  name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Role Role { get { return role; } set { role = value; } }

        public void PrintInformation()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Role: " + Role);
        }
    }
}
