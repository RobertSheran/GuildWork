CREATE TABLE Reservation (
   ReservationID INT IDENTITY(1,1) PRIMARY KEY,
   ContactName varchar(30),
   ContactPhone varchar(20),
   ContactEmail varchar(40),
   CheckInDate date,
   CheckOutDate date,
   PromoCodeID INT FOREIGN KEY REFERENCES PromoCode(PromoCodeID) Null
   )