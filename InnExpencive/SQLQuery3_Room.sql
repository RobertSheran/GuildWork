USE InnExpensive;
GO

CREATE TABLE Room (
   RoomID INT IDENTITY(1,1) PRIMARY KEY,
   OccupencyLimit smallint,
   [Floor] smallint,
)
GO
