using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
