USE master
GO
 
IF EXISTS(SELECT * FROM sys.databases WHERE Name='MovieDb')
DROP DATABASE MovieDb
GO
 
CREATE DATABASE MovieDb
GO
 
USE MovieDb
GO

CREATE TABLE DVD (
	DVDId int identity(1,1) primary key not null,
	DVDTitle varchar(50) not null,
	RealeaseYear int not null,
    DVDNotes varchar(200) not null,
    Rating varchar(6),
    Director varchar(50),
	)