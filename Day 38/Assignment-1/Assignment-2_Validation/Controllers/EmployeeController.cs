using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-TIC5DM4;Database=EmployeeManagement;Integrated Security=True;";

        // GET: Employee List
        public async Task<IActionResult> Index()
        {
            var employees = await GetAllEmployees();
            return View(employees);
        }

        // GET: Create Employee
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Employee
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Edit Employee
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Edit Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await UpdateEmployee(employee); // This updates the employee in the database
                return RedirectToAction("Index"); // Redirects to employee list after successful update
            }
            return View(employee); // If the model state is invalid, return to the same view with the current employee data
        }



        // GET: View Employee
        public async Task<IActionResult> View(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Delete Employee
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await RemoveEmployee(id);
            return RedirectToAction("Index");
        }

        // ---------------- Utility Methods -------------------

        private async Task<List<Employee>> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT EmployeeID, FirstName, LastName, PhoneNumber, Email, Salary, DateOfBirth, Country, Address, Age FROM EmployeeManagementTable";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Email = reader.GetString(4),
                            Salary = reader.GetDecimal(5),
                            DateOfBirth = reader.GetDateTime(6),
                            Country = reader.GetString(7),
                            Address = reader.GetString(8),
                            Age = reader.GetInt32(9)
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        private async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT EmployeeID, FirstName, LastName, PhoneNumber, Email, Salary, DateOfBirth, Country, Address, Age FROM EmployeeManagementTable WHERE EmployeeID = @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            employee = new Employee
                            {
                                EmployeeID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                Salary = reader.GetDecimal(5),
                                DateOfBirth = reader.GetDateTime(6),
                                Country = reader.GetString(7),
                                Address = reader.GetString(8),
                                Age = reader.GetInt32(9)
                            };
                        }
                    }
                }
            }

            return employee;
        }

        private async Task AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO EmployeeManagementTable 
                              (FirstName, LastName, PhoneNumber, Email, Salary, DateOfBirth, Country, Address, Age) 
                              VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Salary, @DateOfBirth, @Country, @Address, @Age)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", employee.LastName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Country", employee.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Age", employee.Age);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE EmployeeManagementTable 
                              SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, 
                                  Email = @Email, Salary = @Salary, DateOfBirth = @DateOfBirth, 
                                  Country = @Country, Address = @Address, Age = @Age 
                              WHERE EmployeeID = @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", employee.LastName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Country", employee.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task RemoveEmployee(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM EmployeeManagementTable WHERE EmployeeID = @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
