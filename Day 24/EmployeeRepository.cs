using Linq_To_Sql;
using System;
using System.Linq;

public class EmployeeRepository
{
    private readonly EmployeeDataContext _context;

    public EmployeeRepository(EmployeeDataContext context)
    {
        _context = context;
    }

    public void ShowAllEmployees()
    {
        var employees = _context.Employees.ToList();
        Console.WriteLine("All Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Gender: {employee.Gender}, Age: {employee.Age}, Salary: {employee.Salary}, DeptId: {employee.DeptId}");
        }
    }

    public void CreateEmployee(string name, char gender, int age, decimal salary, int deptId)
    {
        var newEmployee = new Employee
        {
            Name = name,
            Gender = gender,
            Age = age,
            Salary = salary,
            DeptId = deptId
        };

        _context.Employees.InsertOnSubmit(newEmployee);
        _context.SubmitChanges();

        Console.WriteLine("Employee created successfully.");
    }

    public void UpdateEmployee(int employeeId, string newName, char newGender, int newAge, decimal newSalary, int newDeptId)
    {
        var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
        if (employee != null)
        {
            employee.Name = newName;
            employee.Gender = newGender;
            employee.Age = newAge;
            employee.Salary = newSalary;
            employee.DeptId = newDeptId;

            _context.SubmitChanges();
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void DeleteEmployee(int employeeId)
    {
        var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
        if (employee != null)
        {
            _context.Employees.DeleteOnSubmit(employee);
            _context.SubmitChanges();
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}
