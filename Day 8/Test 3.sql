

select * from products;---print all the details from the products table
select price from products;--print only product_id column
select count(*) as [no_of_rec] from products group by supplied;
select sum(unit) as [total number of units] from products;--prints sum of all the units and
                                                          --change column name as total number of units as reference
select min(price) from products;--prints least price in price column


select count(price) as count_of_prices from products;--prints number of products having prices
