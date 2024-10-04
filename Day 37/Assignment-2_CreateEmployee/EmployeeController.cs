using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models; 
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", MiddleName = "A", LastName = "Doe", Salary = 60000, Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St", Country = "USA", Age = 30, DateOfBirth = new DateTime(1994, 5, 1) },
            new Employee { Id = 2, FirstName = "Jane", MiddleName = "B", LastName = "Smith", Salary = 65000, Email = "jane.smith@example.com", PhoneNumber = "9876543210", Address = "456 Elm St", Country = "USA", Age = 28, DateOfBirth = new DateTime(1996, 3, 10) },
            new Employee { Id = 3, FirstName = "Mike", MiddleName = "C", LastName = "Johnson", Salary = 70000, Email = "mike.johnson@example.com", PhoneNumber = "5555555555", Address = "789 Oak St", Country = "USA", Age = 35, DateOfBirth = new DateTime(1988, 7, 20) },
            new Employee { Id = 4, FirstName = "Emily", MiddleName = "D", LastName = "Davis", Salary = 72000, Email = "emily.davis@example.com", PhoneNumber = "4444444444", Address = "321 Pine St", Country = "USA", Age = 27, DateOfBirth = new DateTime(1996, 1, 15) },
            new Employee { Id = 5, FirstName = "Chris", MiddleName = "E", LastName = "Wilson", Salary = 55000, Email = "chris.wilson@example.com", PhoneNumber = "2222222222", Address = "654 Maple St", Country = "USA", Age = 40, DateOfBirth = new DateTime(1983, 11, 30) }
        };

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View(new Employee()); 
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Max(e => e.Id) + 1; 
                employees.Add(employee);

                return RedirectToAction("Index"); 
            }

            return View(employee);
        }

    }
}