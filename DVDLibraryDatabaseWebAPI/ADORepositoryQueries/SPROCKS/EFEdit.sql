Create PROCEDURE EFMovieUpdate (
    @DVDId int,
	@DVDTitle varchar(50),
	@RealeaseYear int,
    @DVDNotes varchar(200),
    @Rating varchar(6),
    @Director varchar(50)
)
AS
   update DVDs
    set DVDTitle = @DVDTitle,
    RealeaseYear = @RealeaseYear,
    DVDNotes = @DVDNotes,
    Rating = @Rating,
    Director = @Director
    where DVDId=@DVDId
