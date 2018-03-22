CREATE TABLE Detail (
   DetailID INT IDENTITY(1,1) PRIMARY KEY,
   Discription varchar(60),
   Cost decimal (6,2),
   ReservationID INT FOREIGN KEY REFERENCES Billing(ReservationID) NOT NULL,
   AddOnID Int FOREIGN KEY REFERENCES AddOn(AddOnID) NOT NULL
)