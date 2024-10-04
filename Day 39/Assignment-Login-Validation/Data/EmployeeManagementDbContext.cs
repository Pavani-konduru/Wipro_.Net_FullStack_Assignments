using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementLogin.Models;
using EmployeeManagementLogin.Models;

namespace EmployeeManagementLogin.Data
{
    public class EmployeeManagementDbContext : IdentityDbContext<User>
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}