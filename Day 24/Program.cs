using Linq_To_Sql;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=DESKTOP-TIC5DM4;Initial Catalog=LinqToSql;Integrated Security=True;Encrypt=False";
        using (var context = new EmployeeDataContext(connectionString))
        {
            var repository = new EmployeeRepository(context);

            //Console.WriteLine("All Employees:");
            repository.ShowAllEmployees();

            Console.WriteLine("\nCreating a new employee...");
            CreateEmployee(repository);

            Console.WriteLine("\nUpdating an employee...");
            UpdateEmployee(repository);

           Console.WriteLine("\nDeleting an employee...");
           DeleteEmployee(repository);

            Console.WriteLine("\nUpdated employee list:");
            repository.ShowAllEmployees();
        }
    }

    static void CreateEmployee(EmployeeRepository repository)
    {
        Console.WriteLine("Enter Employee Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Gender (M/F):");
        char gender = Console.ReadLine()[0];

        Console.WriteLine("Enter Age:");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Salary:");
        decimal salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Department ID:");
        int deptId = int.Parse(Console.ReadLine());

        repository.CreateEmployee(name, gender, age, salary, deptId);
    }

    static void UpdateEmployee(EmployeeRepository repository)
    {
        Console.WriteLine("Enter Employee ID to update:");
        int employeeId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Name:");
        string newName = Console.ReadLine();

        Console.WriteLine("Enter new Gender (M/F):");
        char newGender = Console.ReadLine()[0];

        Console.WriteLine("Enter new Age:");
        int newAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Salary:");
        decimal newSalary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Department ID:");
        int newDeptId = int.Parse(Console.ReadLine());

        repository.UpdateEmployee(employeeId, newName, newGender, newAge, newSalary, newDeptId);
    }

    static void DeleteEmployee(EmployeeRepository repository)
    {
        Console.WriteLine("Enter Employee ID to delete:");
        int employeeId = int.Parse(Console.ReadLine());

        repository.DeleteEmployee(employeeId);
    }
}
