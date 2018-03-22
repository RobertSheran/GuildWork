USE InnExpensive;
GO

CREATE TABLE PromoCode (
   PromoCodeID INT IDENTITY(1,1) PRIMARY KEY,
   StartDate date,
   EndDate date,
   Discount decimal(6,2),
)
GO