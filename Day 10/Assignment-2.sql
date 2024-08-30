create table Orders(
OrderId int identity(1,1) primary key,
OrderDate date not null,
CustomerId int  not null,
TotalAmmount float not null,
);

BEGIN TRANSACTION;
INSERT INTO ORDERS (OrderId, OrderDate, CustomerId, TotalAmmount) 
VALUES(1, '2024-07-15', 104, 140.35);
 SAVE TRANSACTION SAVEPOINT1;

INSERT INTO ORDERS (OrderId, OrderDate, CustomerId, TotalAmmount) 
VALUES(2, '2024-08-15', 105, 200.65);
SAVE TRANSACTION SAVEPOINT2;

INSERT INTO ORDERS (OrderId, OrderDate, CustomerId, TotalAmmount) 
VALUES(3, '2024-05-25', 105, 257.90);
SAVE TRANSACTION SAVEPOINT3;

ROLLBACK TRANSACTION SAVEPOINT3;

SELECT * FROM ORDERS;
COMMIT TRANSACTION;


