CREATE DATABASE EmployeeManagerPro;
Use EmployeeManagerPro;
Go
CREATE TABLE EmployeeManagerTable (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    EmployeeType NVARCHAR(20) NOT NULL CHECK (EmployeeType IN ('Permanent', 'Contractual')),
    Bonus DECIMAL(18, 2) DEFAULT 0.00,
    Pay DECIMAL(18, 2) DEFAULT 0.00
);
Go
