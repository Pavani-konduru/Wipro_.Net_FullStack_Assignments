using System;

namespace Day_41_API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        // Sample Data
        public static List<Employee> GetSampleData()
        {
            return new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "Rahul", MiddleName = "P", LastName = "Kumhar", Country = "India", Gender = "Male", PhoneNumber = "9876543210", DateOfBirth = new DateTime(1999, 10, 10), Age = 26 },
                new Employee { EmployeeId = 2, FirstName = "Pradeep", MiddleName = "R", LastName = "Samaobat", Country = "India", Gender = "Male", PhoneNumber = "9876543210", DateOfBirth = new DateTime(2020, 7, 8), Age = 24 },
                new Employee { EmployeeId = 3, FirstName = "Surya", MiddleName = "J", LastName = "Mane", Country = "India", Gender = "Male", PhoneNumber = "9876543210", DateOfBirth = new DateTime(1998, 5, 5), Age = 25 },
            };
        }
    }
}
