using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_27
{
    public class DataService
    {
        public void AddEmployee(Employee employee)
        {
            using (var context = new EntityCrudEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var context = new EntityCrudEntities())
            {
                return context.Employees.Find(id);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var context = new EntityCrudEntities())
            {
                return context.Employees.ToList();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var context = new EntityCrudEntities())
            {
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new EntityCrudEntities())
            {
                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
        }
    }
}
