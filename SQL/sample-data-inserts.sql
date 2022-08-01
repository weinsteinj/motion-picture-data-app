--sample data to insert and test with

INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Top Gun', 'Really cool Cold War era action flick about Naval aviators and their adventures, on- and off-shore.', 1986);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Henry Stone Part 1', 'Adventures in Egypt', 1980);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Henry Stone Part 2', 'Adventures in Peru', 1985);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Henry Stone Part 3', 'Adventures in Egypt', 1990);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Space Skirmish Part 1', 'Saturn Spins', 1986);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Space Skirmish Part 2', 'Adventures in the Khyber Belt', 1999);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Space Skirmish Part 3', 'Black Holes and Beyond', 2005);
INSERT INTO movies (Name, Description, ReleaseYear) 
VALUES ('Space Skirmish Part 4', 'Jupiter on Fire', 2018);

SELECT * FROM movies;

INSERT INTO movies ( Name, Description, ReleaseYear) 
VALUES ('Space Balls', 'Judy-Jan', 2000);

DELETE FROM movies WHERE Id = 1;