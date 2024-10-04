using Microsoft.AspNetCore.Mvc;
using Day_41_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Day_41_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employee/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.EmployeeApiTable.ToListAsync(); 
        }

        // GET: api/Employee/details/{id}
        [HttpGet("details/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.EmployeeApiTable.FindAsync(id); // Find employee by ID

            if (employee == null)
            {
                return Ok(employee);
            }

            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            _context.EmployeeApiTable.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee); // Return created employee
        }
    }
}
