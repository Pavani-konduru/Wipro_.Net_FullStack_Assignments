using Day_41_API.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
    }

    public DbSet<Employee> EmployeeApiTable { get; set; }  
}
