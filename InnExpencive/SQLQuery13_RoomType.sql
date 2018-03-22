create table RoomType(
   RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
   TypeDiscription VarChar(60) NOT NULL,
   RoomID INT FOREIGN KEY REFERENCES Room(RoomID) NOT NULL
)
GO