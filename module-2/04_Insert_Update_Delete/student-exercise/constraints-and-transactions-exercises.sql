-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
insert into actor (first_name, last_name)
VALUES ('Hampton', 'Avenue')
insert into actor (first_name, last_name)
VALUES ('Lisa', 'Byway')
select * from actor where first_name ='Hampton' or first_name = 'Lisa'

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
insert into film (title, description, release_year, language_id, rental_duration, rental_rate, length, replacement_cost)
VALUES('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in
-- ancient Greece', 2008, (select language.language_id from language where language.name='English'), 7, 3.99, 198, 8)
select * from film where film.title='Euclidean PI'

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
insert into film_actor (film_id, actor_id)
values ((select film.film_id from film where film.title='Euclidean PI'), (select actor.actor_id from actor where first_name='Hampton' and last_name='Avenue'))
insert into film_actor (film_id, actor_id)
values ((select film.film_id from film where film.title='Euclidean PI'), (select actor.actor_id from actor where first_name='Lisa' and last_name='Byway'))
select * from film_actor where film_id=(select film.film_id from film where film.title='Euclidean PI')

-- 4. Add Mathmagical to the category table.
insert into category (name)
values ('Mathmagical')
select * from category where name = 'Mathmagical'

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
insert into film_category (film_id, category_id)
values ((select film_id from film where title='Euclidean PI'), (select category_id from category where name='Mathmagical'))
insert into film_category (film_id, category_id)
values ((select film_id from film where title='EGG IGBY'), (select category_id from category where name='Mathmagical'))
insert into film_category (film_id, category_id)
values ((select film_id from film where title='KARATE MOON'), (select category_id from category where name='Mathmagical'))
insert into film_category (film_id, category_id)
values ((select film_id from film where title='RANDOM GO'), (select category_id from category where name='Mathmagical'))
insert into film_category (film_id, category_id)
values ((select film_id from film where title='YOUNG LANGUAGE'), (select category_id from category where name='Mathmagical'))
--looking at results
select category.name, title from film
join film_category on film.film_id=film_category.film_id
join category on film_category.category_id=category.category_id
where category.name='Mathmagical'

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
begin transaction
update film
set rating='G'
from film
join film_category on film.film_id=film_category.film_id
join category on film_category.category_id=category.category_id
where category.name='Mathmagical'
commit transaction
--looking at the results
select title, rating from film
join film_category on film.film_id=film_category.film_id
join category on film_category.category_id=category.category_id
where category.name='Mathmagical'

-- 7. Add a copy of "Euclidean PI" to all the stores.
insert into inventory (film_id, store_id)
select (select film_id from film where title='Euclidean PI'), store.store_id from store

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE> No; the film cannot be deleted from film because the film.film_id is linked in and used in another table, film_actor.
delete from film
where title='Euclidean PI'

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE> No; here, the category cannot be deleted because the category_id key is linked to and being used in film_category.
delete from category
where name = 'Mathmagical'

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE> Yes; the key itself was not deleted, only the links between this key and other film keys, and nothing depends on that link for existing.
delete from film_category
where film_category.category_id=(select category.category_id from category where name='Mathmagical')

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE> Deleting the category works because we've now removed the dependant tie in the film_category table. Deleting the film_actor table still references the film table on film_id.
delete from category
where name='Mathmagical'
select name from category where name ='Mathmagical' --nothing there

delete from film
where title='Euclidean PI'

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
--The link to film_category is no longer necessary because it was deleted.
--Inventory would need to sever the tie by deleting any copies/inventory in the stores (in inventory table). Also, any dependant ties to the film_actor table must be removed. 