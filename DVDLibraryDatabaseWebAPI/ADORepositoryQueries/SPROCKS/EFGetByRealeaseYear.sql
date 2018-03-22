CREATE PROCEDURE EFGetByRealeaseYear(
@RealeaseYear varchar(50)
)
AS

SELECT *
FROM DVDs
Where DVDs.RealeaseYear=@RealeaseYear

GO