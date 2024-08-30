create table customers(
customer_id int,
customer_name varchar(50),
customer_email varchar(100),
address varchar(100));

insert into customers(customer_id, customer_name, customer_email, address)
values(10,'abhi','abhi@gmail.com','andhra pradesh'),
(20,'bhanu','bhanu@gmail.com','andhra pradesh'),
(30,'chinni','chinni@gmail.com','chandigarh'),
(40,'dhanu','dhanu@gmail.com','delhi'),
(50,'alex','alex@gmail.com','kerala'),
(60,'latha','latha@gmail.com','karnataka'),
(70,'sruthi','sruthi@gmail.com','tamilnadu');

update customers set customer_name = 'latharani' where customer_name ='latha';

select * from customers;
select distinct customer_name from customers;
select customer_name from customers;
select count (distinct(customer_id)) from customers;
select customer_email from customers where customer_name = 'abhiram';
select * from customers where address like '%andhra pradesh';
select count (distinct(address)) from customers;
select distinct address from customers;
select customer_name,customer_email from customers where address like '%andhra pradesh';

drop table customers;
truncate table customers;

