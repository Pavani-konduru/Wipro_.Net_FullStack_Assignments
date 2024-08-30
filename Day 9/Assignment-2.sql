--Assignment 2: Utilize a subquery to find customers who have placed orders above 
--the average order value, and write a UNION query to combine two SELECT statements 
--with the same number of columns.

select distinct customer.customerid, customer.customername
from customer
join orders on customer.customerid = orders.CustomerId
where orders.ordervalue > (
		select AVG (ordervalue)
		from orders);

--query1: customers who have placed atleast on order
select distinct c.customerid, c.customername
from customer c
join orders o on o.customerid = c.customerid

--query2: customers who have not placed any order
select distinct c.customerid, c.customername
from customer c
Left join orders o on o.customerid = c.customerid
where o.orderid is null;

--query1: customers who have placed atleast on order
select distinct c.customerid, c.customername
from customer c
join orders o on o.customerid = c.customerid
union
--query2: customers who have not placed any order
select distinct c.customerid, c.customername
from customer c
Left join orders o on o.customerid = c.customerid
where o.orderid is null;



