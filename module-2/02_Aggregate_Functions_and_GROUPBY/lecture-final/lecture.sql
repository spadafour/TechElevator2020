-- ORDERING RESULTS

-- Populations of all countries in descending order
select population, name from country order by population desc
--Names of countries and continents in ascending order
select name,continent from country order by continent, name
-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
select top 10 name,lifeexpectancy from country where lifeexpectancy is not null order by lifeexpectancy desc
-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
select name + ', ' + district from city
where district in ('California','Oregon','Washington')
order by district, name

select name + ', ' + district from city
where district='California' or district='Oregon' or district='Washington'
order by district, name
-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
select avg(lifeexpectancy) from country;
-- Total population in Ohio
select sum(population)
from city
where district='Ohio'
-- The surface area of the smallest country in the world
select min(surfacearea) from country
-- The 10 largest countries in the world
select top 10 * from country order by surfacearea desc
-- The number of countries who declared independence in 1991
select count(*) from country where indepyear = 1991
-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
select count(countrycode) as Countries,language from countrylanguage
group by language
order by Countries desc
-- Average life expectancy of each continent ordered from highest to lowest
select AVG(lifeexpectancy) as Avg_Lifeexpectancy,continent from country
group by continent
order by Avg_Lifeexpectancy desc
-- Exclude Antarctica from consideration for average life expectancy
select AVG(lifeexpectancy) as Avg_Lifeexpectancy,continent from country
where continent != 'Antarctica'
group by continent
order by Avg_Lifeexpectancy desc

-- Sum of the population of cities in each state in the USA ordered by state name
select sum(population),district from city
where countrycode='USA'
group by district
order by district
-- The average population of cities in each state in the USA ordered by state name
select avg(population),district from city
where countrycode='USA'
group by district
order by district
-- SUBQUERIES
-- Find the names of cities under a given government leader
select * from city where countrycode in (select code from country where headofstate='Beatrix')
select headofstate from country
select name,(select headofstate from country where code=countrycode) as Leader from city
order by Leader
-- Find the names of cities whose country they belong to has not declared independence yet
select name,(select headofstate from country where code=countrycode) as Leader from city
where countrycode not in (select code from country where indepyear is null)
order by Leader
-- Additional samples
-- You may alias column and table names to be more descriptive
SELECT name AS city_name
FROM city AS cities;
-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.
select * from city as c where c.district='Washington'
-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)
SELECT name, population
FROM city
WHERE countryCode = 'USA'
ORDER BY name ASC, population DESC;
-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)
select name, population from city order by name
offset 200 rows fetch next 100 rows only
-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.
SELECT (name + ' is in the state of ' + district) AS city_state
FROM city
WHERE countryCode = 'USA';
-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table
SELECT COUNT(name) AS city_count
FROM city;
-- Also counts the number of rows in the city table
SELECT COUNT(population)
FROM city;

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.
SELECT SUM(population) AS total_city_population, COUNT(population) AS number_of_cities, AVG(population) AS avergage_population
FROM city;
-- Gets the MIN population and the MAX population from the city table.
SELECT MIN(population) AS smallest_population, MAX(population) AS largest_population
FROM city;
-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
SELECT countrycode, MIN(population), MAX(population)
FROM city
GROUP BY countrycode;