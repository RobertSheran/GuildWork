CREATE PROCEDURE EFGetByTitle(
@DVDTitle varchar(50)
)
AS

SELECT *
FROM DVDs
Where DVDs.DVDTitle=@DVDTitle

GO