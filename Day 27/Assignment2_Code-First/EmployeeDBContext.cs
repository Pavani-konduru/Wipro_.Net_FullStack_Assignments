using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CodeFirstDemo
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());


        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Department> Departments { get; set;}
    }
}
