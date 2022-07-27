--drop db, table if exists (@idempotent), then create table with data columns and constraints as needed 

DROP TABLE IF EXISTS movies; 

CREATE TABLE movies (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(500),
	ReleaseYear int NOT NULL 
);

