using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{      
        public class TestConsoleSeed : DropCreateDatabaseIfModelChanges<EmployeeDBContext>
        {
            protected override void Seed(EmployeeDBContext context)
            {
           // int v = context.Entry<Department>().GetHashCode(
               // new Department { DeptName = "Sales Department" });
               
            Department d1 = new Department();
            d1.DeptName = "PAYROLL";

            Department d2 = new Department();
            d1.DeptName = "IT";
            Department d3 = new Department();
            d1.DeptName = "Manager";

            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);


            context.SaveChanges();
            base.Seed(context);
            }
        
        }

    }



