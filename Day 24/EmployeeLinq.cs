using System.Data.Linq.Mapping;

[Table(Name = "Employee")]
public class Employee
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int EmployeeId { get; set; }

    [Column]
    public string Name { get; set; }

    [Column]
    public char Gender { get; set; }

    [Column]
    public int Age { get; set; }

    [Column]
    public decimal Salary { get; set; }

    [Column]
    public int DeptId { get; set; }
}
