-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
select * from payment where payment_id=16666
-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
select * from payment
join customer on payment.customer_id = customer.customer_id
where payment_id=16666
-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
select payment.*,customer.first_name,customer.last_name from payment
join customer on payment.customer_id = customer.customer_id
where payment_id=16666
-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
select payment.*,customer.first_name,customer.last_name,rental.return_date from payment
join customer on payment.customer_id = customer.customer_id
join rental on rental.rental_id = payment.rental_id
where payment_id=16666

-- What did they rent? Film id can be gotten through inventory.
select payment.*,customer.first_name,customer.last_name,rental.return_date,film.title from payment
join customer on payment.customer_id = customer.customer_id
join rental on rental.rental_id = payment.rental_id
join inventory on inventory.inventory_id = rental.inventory_id
join film on inventory.film_id = film.film_id
where payment_id=16666

-- What if we wanted to know who acted in that film?
select payment.*,customer.first_name,customer.last_name,rental.return_date,film.title,actor.first_name,actor.last_name,film.film_id from payment
join customer on payment.customer_id = customer.customer_id
join rental on rental.rental_id = payment.rental_id
join inventory on inventory.inventory_id = rental.inventory_id
join film on inventory.film_id = film.film_id
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where payment_id=16666
-- What if we wanted a list of all the films and their categories ordered by film title
select title,name from film
join film_category as fc on fc.film_id = film.film_id
join category on category.category_id = fc.category_id
order by title
-- Show all the 'Comedy' films ordered by film title
select title,name from film
join film_category as fc on fc.film_id = film.film_id
join category on category.category_id = fc.category_id
where category.name = 'Comedy'
order by title

-- Finally, let's count the number of films under each category
select name,count(title) as number from film
join film_category as fc on fc.film_id = film.film_id
join category on category.category_id = fc.category_id
group by name
order by number
-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)
USE World
-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.
SELECT c.name, ci.name
FROM country c
LEFT JOIN city ci ON c.capital = ci.id
-- Let's display a list of all countries and their capitals, if they have some.

-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- *********** UNION *************
USE dvdstore
-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates
select first_name from actor
union
select first_name from customer
-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
select first_name,'A' from actor
union
select first_name,'C' from customer
