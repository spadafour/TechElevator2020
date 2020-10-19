-- Switch to the system (aka master) database
USE master;
GO

-- Delete the ArtGallery Database (IF EXISTS)
DROP DATABASE IF EXISTS ArtGallery;

-- Create a new ArtGallery Database
CREATE DATABASE ArtGallery;
GO

-- Switch to the ArtGallery Database
USE ArtGallery
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE customers
(
	customerId		int				identity(1,1),
	name			varchar(64)		not null,
	address			varchar(100)	not null,
	phone			varchar(11)		null,
	memberSince		datetime	not null,
	constraint pk_customers primary key (customerId)
);

create table art_artist
(
	artId	int	not null,
	artistId	int		not null,
	constraint pk_art_artist primary key (artId, artistId),
);

CREATE TABLE artists
(
	artistId		int				identity(1,1),
	firstName		varchar(64)		not null,
	lastName		varchar(64)		not null,

	constraint pk_artists primary key (artistId)
);

CREATE TABLE art
(
	artId		int				identity(1,1),
	title			varchar(64)		not null,

	constraint pk_art primary key (artId),
);

CREATE TABLE Purchase
(
	customerId	int not null,
	artId	int not null,
	purchaseDate	datetime	not null,
	price	money	not null,

	constraint pk_customer_purchase primary key(customerId,artId)
);
-- let's add the relationships
ALTER TABLE art_artist ADD constraint fk_art_artist_art foreign key(artId) references art(artId);
ALTER TABLE art_artist ADD constraint fk_art_artist_artists foreign key(artistId) references artists(artistId);
ALTER TABLE customers ADD constraint memberDefault DEFAULT GETDATE() FOR memberSince;
ALTER TABLE Purchase ADD constraint fk_purchase_customer foreign key(customerId) references customers(customerId);
ALTER TABLE Purchase ADD constraint fk_purchase_art foreign key(artId) references art(artId);


-- add data
commit
