CREATE TABLE AddOnPrice (
   AddOnPriceID INT IDENTITY(1,1) PRIMARY KEY,
   AddOnID INT FOREIGN KEY REFERENCES Reservation(ReservationID) not null,
   AddOnPrice decimal(6,2) not null,
      StartDate date not null,
   EndDate date not null,
)