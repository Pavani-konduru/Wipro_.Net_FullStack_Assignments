create table inventory(
ItemID int primary key,
ItemName varchar(50),
stockQuantity int
);

Insert into inventory(ItemID, ItemName, stockQuantity)
values(1,'widget',100);

Insert into inventory(ItemID, ItemName, stockQuantity)
values(2,'Gadget',200);

begin transaction;
select * from inventory with(ROWLOCK, UPDLOCK) WHERE ItemId = 1;

update inventory set stockQuantity = stockQuantity - 10 where ItemID = 1;
commit TRANSACTION;

begin TRANSACTION;
select * from inventory with(ROWLOCK, UPDLOCK) WHERE ItemId = 1;

update inventory set stockQuantity = stockQuantity + 20 where ItemID = 1;
commit TRANSACTION;

set transaction Isolation level read uncommitted;
begin transaction;
select * from inventory
where ItemID =1;
commit transaction;

set transaction Isolation level read committed;
begin transaction;
select * from inventory
where ItemID =1;
commit transaction;

set transaction Isolation level repeatable read;
begin transaction;
select * from inventory
where ItemID =1;
commit transaction;

set transaction Isolation level serializable;
begin transaction;
select * from inventory
where ItemID =1;
commit transaction;





