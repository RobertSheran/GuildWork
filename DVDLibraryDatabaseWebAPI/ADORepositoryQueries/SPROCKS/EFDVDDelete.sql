CREATE PROCEDURE EFDVDDelete (
    @DVDId int
)
AS
   Delete from DVDs
   where DVDs.DVDId = @DVDId
 GO