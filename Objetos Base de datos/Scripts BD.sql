MYSQL
==========
CREATE DATABASE db_challengeEmision;

CREATE TABLE Bookswishlist(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	User VARCHAR(50),	
	CreationDate VARCHAR(50),
	NumberBookswishlist INTEGER
);

CREATE TABLE Bookswishlist_Book(
	IdBookswishlist INT ,
	IdBook VARCHAR(50) ,
	NumberBook INTEGER,
	PRIMARY KEY(IdBookswishlist,IdBook)
);

CREATE TABLE Book(
	Id VARCHAR(50)  PRIMARY KEY,
	Title VARCHAR(255),
	Author VARCHAR(255),
	Publisher VARCHAR(255)
);