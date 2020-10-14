-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
select title from film
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where first_name = 'Nick' and last_name = 'Stallone'

-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
select title from film
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where first_name = 'Rita' and last_name = 'Reynolds'

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
select title, first_name, last_name from film
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where first_name = 'Judy' or first_name = 'River' and last_name = 'Dean'

-- 4. All of the the ‘Documentary’ films
-- (68 rows)
select title from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name = 'Documentary'

-- 5. All of the ‘Comedy’ films
-- (58 rows)
select title from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name = 'Comedy'

-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
select title from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name = 'Children' and rating = 'G'

-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
select title from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name = 'Family' and rating = 'G' and length < 120

-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
select title, description from film
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where first_name = 'Matthew' and last_name = 'Leigh' and rating = 'G'

-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
select title from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name = 'Sci-Fi' and release_year = 2006

-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
select title from film
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where first_name = 'Nick' and last_name = 'Stallone' and category.name = 'Action'

-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
select address, address2, city, district, country from address
join store on address.address_id = store.address_id
join city on address.city_id = city.city_id
join country on city.country_id = country.country_id

-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
select store.store_id, address.address, address.address2, staff.first_name, staff.last_name from store
join address on store.address_id = address.address_id
join staff on store.manager_staff_id = staff.staff_id

-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
select top 10 first_name, last_name, count(rental_id) as 'RentalCount' from customer
join rental on customer.customer_id = rental.customer_id
group by first_name, last_name
order by 'RentalCount' desc

-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
select top 10 first_name, last_name, SUM(amount) as 'DollarsSpent' from customer
join payment on customer.customer_id = payment.customer_id
group by first_name, last_name
order by 'DollarsSpent' desc

-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that an employee may work at multiple stores.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)
select store.store_id, address, address2, COUNT(rental.rental_id) as 'RentalCount', SUM(amount) as 'TotalSales', CAST(AVG(amount) as numeric(5,2)) as 'AvgSale' from store
join address on address.address_id = store.address_id
join inventory on store.store_id = inventory.store_id
join rental on inventory.inventory_id = rental.inventory_id
join payment on rental.rental_id = payment.rental_id
group by store.store_id, address, address2

-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
select top 10 title, count(rental.inventory_id) as 'TotalRentals' from film
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
group by title
order by 'TotalRentals' desc

-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
select top 10 category.name, count(rental.inventory_id) as 'TotalRentals' from category
join film_category on category.category_id = film_category.category_id
join film on film_category.film_id = film.film_id
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
group by category.name
order by 'TotalRentals' desc

-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
select top 5 title, count(rental.inventory_id) as 'TotalRentals' from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
where category.name = 'Action'
group by title
order by 'TotalRentals' desc

-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
select top 10 actor.actor_id, first_name, last_name, COUNT(rental.inventory_id) as 'TotalRentals' from actor
join film_actor on actor.actor_id = film_actor.actor_id
join film on film_actor.film_id = film.film_id
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
group by actor.actor_id, first_name, last_name
order by 'TotalRentals' desc

-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
select top 5 first_name, last_name, COUNT(rental.inventory_id) as 'TotalRentals' from actor
--get to category for comedy
join film_actor on actor.actor_id = film_actor.actor_id
join film on film_actor.film_id = film.film_id
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
--get to rental for sales
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
where category.name = 'Comedy'
group by actor.actor_id, first_name, last_name
order by 'TotalRentals' desc