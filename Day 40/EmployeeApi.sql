CREATE DATABASE EMPLOYEEAPI;
GO;
USE EMPLOYEEAPI;
GO
EXEC sp_rename 'EmployeeApiTable.id', 'Employeeid', 'COLUMN';


-- Create Employees Table
CREATE TABLE EmployeeApiTable (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(15),
    DateOfBirth DATE NOT NULL,
    Age INT NOT NULL
);
GO
INSERT INTO EmployeeApiTable(FirstName, MiddleName, LastName, Country, Gender, PhoneNumber, DateOfBirth, Age)
VALUES ('John', 'A', 'Doe', 'USA', 'Male', '1234567890', '1990-01-01', 34);
GO