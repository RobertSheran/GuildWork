CREATE PROCEDURE GetByTitle(
@DVDTitle varchar(50)
)
AS

SELECT *
FROM DVD
Where DVD.DVDTitle=@DVDTitle

GO