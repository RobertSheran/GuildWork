USE InnExpensive;
GO

CREATE TABLE AddOn (
   AddOnID INT IDENTITY(1,1) PRIMARY KEY,
   AddOnName VarChar(30),
   AddOnPrice decimal(6,2),
)
GO


