-- The name and population of all cities in the USA with a population of greater than 1 million people
select name,population from city where countrycode='USA' and population > 1000000
-- The name and population of all cities in China with a population of greater than 1 million people
select name, population from city where countrycode='CHN' and population > 1000000
-- The name and region of all countries in North or South America
 select name,region from country where continent IN ('North America','South America')
 
-- The name, continent, and head of state of all countries whose form of government is a monarchy
select NAME,continent,headofstate from country where governmentform ='Monarchy'
-- The name, country code, and population of all cities with a population less than one thousand people
SELECT name, countrycode, population FROM city WHERE population < 1000

-- The name and region of all countries in North or South America except for countries in the Caribbean
select name, region from country where continent IN ('North America','South America') and region != 'Caribbean'
-- The name, population, and GNP of all countries with a GNP greater than $1 trillion dollars and a population of less than 1 billion people
SELECT name, population, gnp FROM country WHERE gnp > 1000000 AND population < 1000000000;

-- The name and population of all cities in Texas that have a population of greater than 1 million people
select name,population from city where district = 'Texas' and population > 1000000
-- The name and average life expectancy of all countries in southern regions
select name, lifeexpectancy from country where region like '%south%'
-- The name and average life expectancy of all countries in southern regions for which an average life expectancy has been provided (i.e. not equal to null)
select name, lifeexpectancy from country where region like '%south%' and lifeexpectancy is not null

-- The name, continent, GNP, and average life expectancy of all countries in Africa or Asia that have an average life expectancy of at least 70 years and a GNP between $1 million and $100 million dollars
select name, continent, gnp, lifeexpectancy from country 
where continent in ('Africa','Asia') 
and lifeexpectancy >= 70
and gnp between 100000 and 100000000