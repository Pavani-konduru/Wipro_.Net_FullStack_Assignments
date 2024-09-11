using System.Data.Linq;

public class EmployeeDataContext : DataContext
{
    public Table<Employee> Employees;

    public EmployeeDataContext(string connection) : base(connection)
    {
    }
}
