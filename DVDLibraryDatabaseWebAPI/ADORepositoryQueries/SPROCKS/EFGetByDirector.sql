CREATE PROCEDURE EFGetByDirector(
@Director varchar(50)
)
AS

SELECT *
FROM DVDs
Where DVDs.Director=@Director

GO