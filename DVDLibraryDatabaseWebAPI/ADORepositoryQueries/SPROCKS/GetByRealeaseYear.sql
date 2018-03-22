CREATE PROCEDURE GetByRealeaseYear(
@RealeaseYear varchar(50)
)
AS

SELECT *
FROM DVD
Where DVD.RealeaseYear=@RealeaseYear

GO