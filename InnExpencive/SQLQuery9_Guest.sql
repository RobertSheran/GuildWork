CREATE TABLE Guest (
   GuestID INT IDENTITY(1,1) PRIMARY KEY,
   GuestName varchar(30),
   Age smallint,
   ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) NOT NULL
)
GO
