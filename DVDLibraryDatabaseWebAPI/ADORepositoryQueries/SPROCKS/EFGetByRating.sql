CREATE PROCEDURE EFGetByRating(
@Rating varchar(50)
)
AS

SELECT *
FROM DVDs
Where DVDs.Rating=@Rating

GO