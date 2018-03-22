CREATE TABLE Billing (
   GrandTotal decimal(8,2) NOT NULL,
   Tax decimal (4,2) Null,
   ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) PRIMARY KEY NOT NULL,
   AddOnID INT FOREIGN KEY REFERENCES AddOn(AddOnID) NULL,
)