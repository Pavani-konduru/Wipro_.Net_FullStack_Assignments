using System;
using System.Data.SqlClient;
using System.Configuration;

class Program
{
    public static string connectionString = ConfigurationManager.ConnectionStrings["applicationCS"].ConnectionString;

    static void Main()
    {
        CreateTables(connectionString);

        InsertDepartment(connectionString,  "HR");
        InsertDepartment(connectionString,  "IT");

        //CreateEmployee(connectionString, "Bhavana", 'F', 22, 40000.00m, 1);
        CreateEmployee(connectionString, "Rahul", 'M', 30, 60000.00m, 1);


        ReadEmployees(connectionString);
         UpdateEmployeeSalary(connectionString, "Pavani", 55000.00m);
        ReadEmployees(connectionString);
        DeleteEmployee(connectionString, "Rahul");
        ReadEmployees(connectionString);
    }
    static void CreateTables(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string createEmployeeTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                BEGIN
                    CREATE TABLE Employee (
                        Name NVARCHAR(100),
                        Gender CHAR(1),
                        Age INT,
                        Salary DECIMAL(18, 2),
                        DeptId INT,
                        FOREIGN KEY (DeptId) REFERENCES Department(Id)
                    );
                END";

            string createDepartmentTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Department' AND xtype='U')
                BEGIN
                    CREATE TABLE Department (
                        DeptId INT IDENTITY(1, 1) PRIMARY KEY,
                        Name NVARCHAR(100)
                    );
                END";      
        }
        Console.WriteLine("Employee and Department Table Created successfully.");

    }
    public static void InsertDepartment(string connectionString, string name)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertQuery = @"
            INSERT INTO Department (Name)
            VALUES (@Name);";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();

            }
       }
    }
    static void CreateEmployee(string connectionString, string name, char gender, int age, decimal salary, int deptId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO Employee (Name, Gender, Age, Salary, DeptId)
                VALUES (@Name, @Gender, @Age, @Salary, @DeptId);";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@DeptId", deptId);

                command.ExecuteNonQuery();
               Console.WriteLine("Employee record inserted successfully.");
            }
        }
    }

    static void ReadEmployees(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM Employee;";

            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Employee Records:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name: {reader["Name"]}, Gender: {reader["Gender"]}, Age: {reader["Age"]}, Salary: {reader["Salary"]}, DeptId: {reader["DeptId"]}");
                    }
                }
            }
        }
    }

    static void UpdateEmployeeSalary(string connectionString, string name, decimal newSalary)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateQuery = @"
                UPDATE Employee
                SET Salary = @NewSalary
                WHERE Name = @Name;";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@NewSalary", newSalary);
                command.Parameters.AddWithValue("@Name", name);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} record(s) updated.");
            }
        }
    }

    static void DeleteEmployee(string connectionString, string name)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteQuery = @"
                DELETE FROM Employee
                WHERE Name = @Name;";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", name);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} record(s) deleted.");
            }
        }
    }
}
