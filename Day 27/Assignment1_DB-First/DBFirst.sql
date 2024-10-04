create database EntityCrud;
use EntityCrud;
create table Employee( id int identity primary key,
name varchar(20),
gender varchar(30),
age int,
salary int,
deptId int foreign key references Department(id)
);

insert into Employee values('pavani','F',30,350000,1);
insert into Employee values('Bhavana','F',25,600000,2);
insert into Employee values('Rahul','m',29,400000,1);

create table Department( id int identity primary key,
name varchar(100));

insert into Department values ('HR');
insert into Department values ('IT');

Alter table Employee 
add Country varchar(100);
Alter table Employee 
add PhoneNumber int;

create table Person( id int identity primary key,
Person_name varchar(100), Person_age int, Person_gender varchar(100));


  

select * from Employee;
select * from Department;
