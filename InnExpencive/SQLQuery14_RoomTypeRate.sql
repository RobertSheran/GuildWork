CREATE TABLE RoomTypeRate (
   RoomTypeRateID INT IDENTITY(1,1) PRIMARY KEY,
   RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID) not null,
   RoomRate decimal(9,2) not null,
   StartDate date not null,
   EndDate date not null,
)