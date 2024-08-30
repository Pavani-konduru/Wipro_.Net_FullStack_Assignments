-- Write a Sql query to retrive all columns from a 'customers' table,
-- and modify it to return only the customer name and email address for 
-- customers in a specific city. 

select customer_name, customer_email
from customers
where address like '%Andhra Pradesh';