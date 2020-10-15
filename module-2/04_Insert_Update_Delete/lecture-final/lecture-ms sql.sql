-- INSERT
select * from countrylanguage where countrycode='GBR'
-- 1. Add Klingon as a spoken language in the USA
-- 2. Add Klingon as a spoken language in Great Britain
insert into countrylanguage (countrycode,language,isofficial,percentage) values ('USA','Klingon',1,86)
insert into countrylanguage values('GBR','Klingon',0,0.6)
-- UPDATE

-- 1. Update the capital of the USA to Houston
-- 2. Update the capital of the USA to Washington DC and the head of state
update country set capital = (select top 1 id from city where name='Houston') where code = 'USA'
select * from city where name='Washington'
update country set capital = (select top 1 id from city where name='Washington') where code = 'USA'

-- DELETE

-- 1. Delete English as a spoken language in the USA
-- 2. Delete all occurrences of the Klingon language 
delete countrylanguage where countrycode = 'USA' and language='English'
delete countrylanguage where language='Klingon'
-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
insert into countrylanguage (language,isofficial,percentage,countrycode) values ('Elvish',1,3,'USA')
-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
insert into countrylanguage (language,isofficial,percentage,countrycode) values ('English',1,3,'ZZZ')
insert into countrylanguage (language,isofficial,percentage,countrycode) values ('Elvish',1,3,'GBR')
-- 3. Try deleting the country USA. What happens?


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
insert into countrylanguage (language,isofficial,percentage,countrycode) values ('English',1,3,'USA')

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
update country set continent='Outer Space'

-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
begin transaction
delete countrylanguage
select * from countrylanguage
rollback transaction
-- 2. Try updating all of the cities to be in the USA and roll it back
begin transaction
update city set countrycode='USA'
select * from city
rollback transaction