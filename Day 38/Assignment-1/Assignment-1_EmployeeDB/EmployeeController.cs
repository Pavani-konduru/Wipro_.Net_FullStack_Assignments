using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-TIC5DM4;Database=EmployeeManagement;Integrated Security=True;";

        // GET: Employee list
        public async Task<IActionResult> Index()
        {
            var employees = await GetEmployees();
            return View(employees); // Pass the employee list to the view
        }

        // GET: Render the Create Employee form
        public IActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Handle form submission and create new employee
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await AddEmployee(employee); // Insert the employee into the database
                return RedirectToAction(nameof(Index)); // Redirect to the employee list
            }

            // If the model is invalid, return to the form with error messages
            return View(employee);
        }

        // Method to add employee to the database
        private async Task AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO EmployeeManagementTable (FirstName, MiddleName, LastName, Salary, Email, PhoneNumber, Address, Country, Age, DateOfBirth) " +
                    "VALUES (@FirstName, @MiddleName, @LastName, @Salary, @Email, @PhoneNumber, @Address, @Country, @Age, @DateOfBirth)",
                    connection);

                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@MiddleName", (object)employee.MiddleName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        // Method to get all employees from the database in descending order (newest at top)
        private async Task<List<Employee>> GetEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM EmployeeManagementTable ORDER BY Id DESC", connection);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var employee = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            LastName = reader.GetString(3),
                            Salary = reader.GetDecimal(4),
                            Email = reader.GetString(5),
                            PhoneNumber = reader.GetString(6),
                            Address = reader.GetString(7),
                            Country = reader.GetString(8),
                            Age = reader.GetInt32(9),
                            DateOfBirth = reader.GetDateTime(10)
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }
    }
}
