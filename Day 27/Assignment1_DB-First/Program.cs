using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_27
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Get Employee by ID");
                Console.WriteLine("3. List All Employees");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(dataService);
                        break;
                    case "2":
                        GetEmployeeById(dataService);
                        break;
                    case "3":
                        ListAllEmployees(dataService);
                        break;
                    case "4":
                        UpdateEmployee(dataService);
                        break;
                    case "5":
                        DeleteEmployee(dataService);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddEmployee(DataService dataService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("DeptId: ");
            int deptId = int.Parse(Console.ReadLine());

            Employee employee = new Employee
            {
                name = name,
                gender = gender,
                age = age,
                salary = salary,
                deptId = deptId
            };

            dataService.AddEmployee(employee);
            Console.WriteLine("Employee added successfully.");
        }

        private static void GetEmployeeById(DataService dataService)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = dataService.GetEmployeeById(id);
            if (employee != null)
            {
                Console.WriteLine($"ID: {employee.id}, Name: {employee.name}, Gender: {employee.gender}, Age: {employee.age}, Salary: {employee.salary}, DeptId: {employee.deptId}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        private static void ListAllEmployees(DataService dataService)
        {
            var employees = dataService.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.id}, Name: {employee.name}, Gender: {employee.gender}, Age: {employee.age}, Salary: {employee.salary}, DeptId: {employee.deptId}");
            }
        }

        private static void UpdateEmployee(DataService dataService)
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = dataService.GetEmployeeById(id);
            if (employee != null)
            {
                Console.Write("New Name: ");
                employee.name = Console.ReadLine();
                Console.Write("New Gender: ");
                employee.gender = Console.ReadLine();
                Console.Write("New Age: ");
                employee.age = int.Parse(Console.ReadLine());
                Console.Write("New Salary: ");
                employee.salary = int.Parse(Console.ReadLine());
                Console.Write("New DeptId: ");
                employee.deptId = int.Parse(Console.ReadLine());

                dataService.UpdateEmployee(employee);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        private static void DeleteEmployee(DataService dataService)
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            dataService.DeleteEmployee(id);
            Console.WriteLine("Employee deleted successfully.");
        }
    }
}
