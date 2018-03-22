CREATE PROCEDURE GetByDirector(
@Director varchar(50)
)
AS

SELECT *
FROM DVD
Where DVD.Director=@Director

GO