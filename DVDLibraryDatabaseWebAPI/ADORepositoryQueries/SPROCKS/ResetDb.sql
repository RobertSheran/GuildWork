CREATE PROCEDURE ResetDb
AS
DROP TABLE DVD
CREATE TABLE DVD (
	DVDId int identity(1,1) primary key not null,
	DVDTitle varchar(50) not null,
	RealeaseYear int not null,
    DVDNotes varchar(200) not null,
    Rating varchar(6),
    Director varchar(50),
	)
INSERT INTO DVD( DVDTitle,Rating,Director,DVDNotes,RealeaseYear)
VALUES ('A Great Tale','PG-13','SomeOtherGuy','This really is a great tale!',2015),('A Good Tale','PG','SomeGuy','This is a good tale!',2011)
GO