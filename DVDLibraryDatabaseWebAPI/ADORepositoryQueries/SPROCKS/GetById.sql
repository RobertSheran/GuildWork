CREATE PROCEDURE GetById(
@DVDId int
)
AS

SELECT *
FROM DVD
Where DVD.DVDId=@DVDId

GO