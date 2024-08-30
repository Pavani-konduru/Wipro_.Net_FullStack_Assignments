create database Functions;
GO

create table Products(
ProductID int primary key not null,
ProductName varchar(50),
Price decimal,
Quantity int
);

insert into products(ProductID, ProductName, Price, Quantity)
Values(1,'chai',30,5),
(2,'Biscuit',50,200),
(3,'Rust',10,140),
(4,'Sugar',24.50,30),
(5,'Coffee',78.89,10);

Select * from products;
CREATE FUNCTION CalculateTotal
(@Price decimal(10,2), @Quantity int)
returns decimal(10,2)
AS
Begin
	Return @Price * @Quantity
END

Select ProductName, Quantity, Price,
dbo.CalculateTotal(price, Quantity)
AS Total
From Products
