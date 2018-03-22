Create PROCEDURE MovieUpdate (
    @DVDId int,
	@DVDTitle varchar(50),
	@RealeaseYear int,
    @DVDNotes varchar(200),
    @Rating varchar(6),
    @Director varchar(50)
)
AS
   update DVD set
    DVDTitle = @DVDTitle,
    RealeaseYear = @RealeaseYear,
	DVDNotes = @DVDNotes,
	Rating = @Rating,
	Director = @Director
    where DVDId=@DVDId
