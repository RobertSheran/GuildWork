CREATE PROCEDURE MovieInsert (
    @DVDId int output,
	@DVDTitle varchar(50),
	@RealeaseYear int,
    @DVDNotes varchar(200),
    @Rating varchar(6),
    @Director varchar(50)
)
AS
   INSERT INTO DVD (DVDTitle, RealeaseYear,DVDNotes, Rating,Director)
   VALUES (@DVDTitle,@RealeaseYear , @DVDNotes, @Rating,@Director)
 
   SET @DVDId = SCOPE_IDENTITY()
GO