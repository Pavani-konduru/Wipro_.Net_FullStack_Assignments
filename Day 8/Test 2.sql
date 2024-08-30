create table employees
(empid int,
name varchar(255),
age int ,
constraint age_check check(age>18),
primary key(empid)
);


insert employees (empid,name,age) values(1,'anna',35);
insert employees (empid,name, age) values(2,'mahi',25);
insert employees (empid,name,age) values(3,'rani',19);
select * from employees;
select age from employees;
select age from employees where age>30;