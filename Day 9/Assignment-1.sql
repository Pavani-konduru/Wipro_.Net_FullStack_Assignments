select * from orders;
select* from customer;
select orders.orderid, orders.orderdate, customer.customername,  customer.country from orders join customer on
orders.customerid=customer.customerid;
--Assignment 1: Craft a query using an INNER JOIN to combine 'orders' and 'customers'
-- tables for customers in a specified region, and a LEFT JOIN to display all customers
-- including those without orders.
select customer.customername from orders join customer on orders.customerid=customer.customerid;

select customer.customerid from orders  left outer join customer on orders.customerid=customer.customerid;
select * from orders  left outer join customer on orders.customerid=customer.customerid;

select * from orders  inner join customer on orders.customerid=customer.customerid;
select * from orders  right outer join customer on orders.customerid=customer.customerid;
select * from orders  full outer join customer on orders.customerid=customer.customerid;

select A.customername as name1, B.customername as name2, A.country
from customer A, customer B
where A.customerid <> B.customerid and a.country = b.country

Select distinct customer.customerid, customer.customername
From Customer
Join orders on customer.customerid = orders.customerid
where orders.ordervalue >(
             select AVG(ordervalue)
			 from orders
			 );


--query1: customers who have placed atleast on order
select distinct c.customerid, c.customername
from customer c
join orders o on o.customerid = c.customerid

union

---query2: customers who have not placed any orders
select distinct c.customerid, c.customername
from customer c
left join orders o on o.customerid = c.customerid
where o.orderid is null;

select * from orders;
set IMPLICIT_TRANSACTIONS ON
update orders set
		customerid = 70
		where orderid = 10380
COMMIT

select * from orders;