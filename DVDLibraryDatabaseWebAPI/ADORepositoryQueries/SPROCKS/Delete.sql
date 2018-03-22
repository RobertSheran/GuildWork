CREATE PROCEDURE DVDDelete (
    @DVDId int
)
AS
   Delete from DVD
   where DVD.DVDId = @DVDId
 GO