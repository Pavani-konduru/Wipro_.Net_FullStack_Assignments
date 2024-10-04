using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            //employeeDBContext.Departments.ToList();
            List<Department> depts = employeeDBContext.Departments.ToList();
            foreach(Department dept in depts)
            {
                Console.WriteLine(dept.DeptName);
            }
        }
    }
}
