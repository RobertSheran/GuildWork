CREATE PROCEDURE GetByRating(
@Rating varchar(50)
)
AS

SELECT *
FROM DVD
Where DVD.Rating=@Rating

GO