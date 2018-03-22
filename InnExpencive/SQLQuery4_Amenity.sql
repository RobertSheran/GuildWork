USE InnExpensive;
GO

CREATE TABLE Amenity (
   AmenityID INT IDENTITY(1,1) PRIMARY KEY,
   AmenityName varchar(30),
   AmenityPrice decimal(6,2),
)
GO