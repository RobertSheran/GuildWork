DROP PROCEDURE IF EXISTS dbo.AddState
go

CREATE PROCEDURE AddState (
    @StateId int output,@StateName varchar(50)
	)
AS
   INSERT INTO States(StateName)
   VALUES (@StateName)
   SET @StateId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetStates
go
create procedure GetStates
as
select *
from States

go

DROP PROCEDURE IF EXISTS dbo.AddFinancing
go

CREATE PROCEDURE AddFinancing (
    @Id int output,@FinancingType varchar(50)
	)
AS
   INSERT INTO Financing(FinancingType)
   VALUES (@FinancingType)
   SET @Id = SCOPE_IDENTITY()
GO


DROP PROCEDURE IF EXISTS dbo.GetFinancing
go
create procedure GetFinancing
as
select *
from Financing

go


DROP PROCEDURE IF EXISTS dbo.AddMessage
go

CREATE PROCEDURE AddMessage (
    @ContactId int output,@ContactMessage varchar(400),@ContactName varchar(50),@Email varchar(50),@Phone varchar(30)
	)
AS
   INSERT INTO Contact(ContactMessage,ContactName,Email,Phone)
   VALUES (@ContactMessage,@ContactName,@Email,@Phone)
   SET @ContactId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.AddBodyStyle
go

CREATE PROCEDURE AddBodyStyle (
    @BodyStyleId int output,
	@BodyStyleName varchar(250)
	)
AS
   INSERT INTO BodyStyle(BodyStyleName)
   VALUES (@BodyStyleName)
 
   SET @BodyStyleId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllBodyStyle
go

CREATE PROCEDURE GetAllBodyStyle
AS
select * 
from BodyStyle
GO

DROP PROCEDURE IF EXISTS dbo.GetAllMessages
go

CREATE PROCEDURE GetAllMessages
AS
select * 
from Contact
GO


DROP PROCEDURE IF EXISTS dbo.GetBodyStyle
go

CREATE PROCEDURE GetBodyStyle(@Id int)
AS
select *
from BodyStyle
where BodyStyleId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveBodyStyle
go

CREATE PROCEDURE RemoveBodyStyle(@Id int)
AS
delete
from Cars
where Cars.BodyStyleId=@Id
delete
from BodyStyle
where BodyStyleId=@Id

go
DROP PROCEDURE IF EXISTS dbo.RemoveMessage
go

CREATE PROCEDURE RemoveMessage(@Id int)
AS
delete
from Contact
where ContactId=@Id


--------

GO

DROP PROCEDURE IF EXISTS dbo.AddCarType
go

CREATE PROCEDURE AddCarType (
    @CarTypeId int output,
	@CarTypeName varchar(250)
	)
AS
   INSERT INTO CarType(CarTypeName)
   VALUES (@CarTypeName)
 
   SET @CarTypeId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllCarType
go

CREATE PROCEDURE GetAllCarType
AS
select * 
from CarType
GO

DROP PROCEDURE IF EXISTS dbo.GetCarType
go

CREATE PROCEDURE GetCarType(@Id int)
AS
select *
from CarType
where CarTypeId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveCarType
go

CREATE PROCEDURE RemoveCarType(@Id int)
AS
delete
from Cars
where Cars.CarTypeId=@Id
delete
from CarType
where CarTypeId=@Id

---------------------------

GO

DROP PROCEDURE IF EXISTS dbo.AddColor
go

CREATE PROCEDURE AddColor (
    @ColorId int output,
	@ColorName varchar(250)
	)
AS
   INSERT INTO Colors(ColorName)
   VALUES (@ColorName)
 
   SET @ColorId = SCOPE_IDENTITY()
GO



DROP PROCEDURE IF EXISTS dbo.AddDeal
go

CREATE PROCEDURE AddDeal (
    @SpecialId int output,
	@SpecialMessage varchar(500)
	)
AS
   INSERT INTO Specials(SpecialMessage)
   VALUES (@SpecialMessage)
 
   SET @SpecialId = SCOPE_IDENTITY()
GO


DROP PROCEDURE IF EXISTS dbo.GetAllColor
go

CREATE PROCEDURE GetAllColor
AS
select * 
from Colors
GO


DROP PROCEDURE IF EXISTS dbo.GetAllDeals
go

CREATE PROCEDURE GetAllDeals
AS
select * 
from Specials
GO

DROP PROCEDURE IF EXISTS dbo.GetColor
go

CREATE PROCEDURE GetColor(@Id int)
AS
select *
from Colors
where ColorId=@Id
GO



DROP PROCEDURE IF EXISTS dbo.Purchase
go




CREATE PROCEDURE Purchase (
    @InvoiceId int output,
	@InvoiceName varchar(50),
	@Phone varchar(50),
	@Email varchar(50) null,
	@StreetOne varchar(100)  null,
	@StreetTwo varchar(100) null,
	@City varchar(50)  null,
	@InvoiceState varchar(20)  null,
	@ZipCode varchar(20)  null,
	@Price int  null,
	@PerchaseType varchar(50) null
	)
AS
   INSERT INTO Invoice(InvoiceName, Phone ,Email,StreetOne,StreetTwo,City,InvoiceState,ZipCode, Price ,PerchaseType)
   VALUES ( @InvoiceName,
	@Phone,
	@Email,
	@StreetOne,
	@StreetTwo,
	@City,
	@InvoiceState,
	@ZipCode,
	@Price,
	@PerchaseType)
 
   SET @InvoiceId = SCOPE_IDENTITY()
GO



DROP PROCEDURE IF EXISTS dbo.RemoveColor
go

CREATE PROCEDURE RemoveColor(@Id int)
AS
delete
from Cars
where Cars.ColorId=@Id
delete
from Colors
where ColorId=@Id

-----------------------------------------------------

GO
DROP PROCEDURE IF EXISTS dbo.RemoveDeal
go

CREATE PROCEDURE RemoveDeal(@Id int)
AS
delete
from Specials
where SpecialId=@Id



-----------------------------------------------------
GO
DROP PROCEDURE IF EXISTS dbo.AddInteriorColors
go

CREATE PROCEDURE AddInteriorColors (
    @InteriorColorsId int output,
	@InteriorColorsName varchar(250)
	)
AS
   INSERT INTO InteriorColors(InteriorColorName)
   VALUES (@InteriorColorsName)
 
   SET @InteriorColorsId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllInteriorColors
go

CREATE PROCEDURE GetAllInteriorColors
AS
select * 
from InteriorColors
GO

DROP PROCEDURE IF EXISTS dbo.GetInteriorColors
go

CREATE PROCEDURE GetInteriorColors(@Id int)
AS
select *
from InteriorColors
where InteriorColorId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveInteriorColors
go

CREATE PROCEDURE RemoveInteriorColors(@Id int)
AS
delete
from Cars
where Cars.InteriorColorId=@Id
delete
from InteriorColors
where InteriorColorId=@Id

---------------------------------------

GO

DROP PROCEDURE IF EXISTS dbo.AddTransmission
go

CREATE PROCEDURE AddTransmission (
    @TransmissionId int output,
	@TransmissionName varchar(250)
	)
AS
   INSERT INTO Transmission(TransmissionName)
   VALUES (@TransmissionName)
 
   SET @TransmissionId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllTransmission
go

CREATE PROCEDURE GetAllTransmission
AS
select * 
from Transmission
GO

DROP PROCEDURE IF EXISTS dbo.GetTransmission
go

CREATE PROCEDURE GetTransmission(@Id int)
AS
select *
from Transmission
where TransmissionId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveTransmission
go

CREATE PROCEDURE RemoveTransmission(@Id int)
AS
delete
from Cars
where Cars.TransmissionId=@Id
delete
from Transmission
where TransmissionId=@Id

---------------------------------

GO

DROP PROCEDURE IF EXISTS dbo.AddMake
go

CREATE PROCEDURE AddMake (
    @MakeId int output,
	@MakeName varchar(250)
	)
AS
   INSERT INTO Make(MakeName)
   VALUES (@MakeName)
 
   SET @MakeId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllMake
go

CREATE PROCEDURE GetAllMake
AS
select * 
from Make
GO

DROP PROCEDURE IF EXISTS dbo.GetMake
go

CREATE PROCEDURE GetMake(@Id int)
AS
select *
from Make
where MakeId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveMake
go

CREATE PROCEDURE RemoveMake(@Id int)
AS

delete Cars
from Cars
inner join CarModel on Cars.CarModelId = CarModel.CarModelId
inner join Make on CarModel.MakeId = Make.MakeId
where Make.MakeId = @Id

delete
from CarModel
where CarModel.MakeId = @Id

delete
from Make
where MakeId=@Id

--------------------------------------

GO

DROP PROCEDURE IF EXISTS dbo.AddCarModel
go

CREATE PROCEDURE AddCarModel(
    @CarModelId int output,
	@CarModelName varchar(250),
	@MakeId int
	)
AS
   INSERT INTO CarModel(MakeId,CarModelName)
   VALUES (@MakeId,@CarModelName)
 
   SET @CarModelId = SCOPE_IDENTITY()
GO

DROP PROCEDURE IF EXISTS dbo.GetAllCarModel
go

CREATE PROCEDURE GetAllCarModel
AS
select * 
from CarModel
GO

DROP PROCEDURE IF EXISTS dbo.GetCarModel
go

CREATE PROCEDURE GetCarModel(@Id int)
AS
select *
from CarModel
where CarModelId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveCarModel
go

CREATE PROCEDURE RemoveCarModel(@Id int)
AS
delete
from Cars
where Cars.CarModelId=@Id
delete
from CarModel
where CarModelId=@Id

------------------------------------

GO

DROP PROCEDURE IF EXISTS dbo.AddCars
go

CREATE PROCEDURE AddCars (
	@Sold bit,
    @CarId int output,
	@Vin int,
	@SalesPrice int,
	@MSRP int,
	@CarYear int,
	@Mileage int,
	@Special bit,
	@Photo nvarchar(250),
	@Discription varchar(400),
	@BodyStyleId int,
    @ColorId int,
    @CarTypeId int,
	@TransmissionId int,
	@InteriorColorId int,
	@CarModelId int,
	@AspNetUserId nvarchar(128)
	
)
AS
   INSERT INTO Cars(Vin,Sold ,SalesPrice,MSRP, CarYear,Mileage,Special, Photo, Discription,BodyStyleId,ColorId,CarTypeId,TransmissionId,InteriorColorId,CarModelId,AspNetUserId)
   VALUES (@Vin,@Sold, @SalesPrice,@MSRP, @CarYear,@Mileage,@Special, @Photo, @Discription,@BodyStyleId,@ColorId,@CarTypeId,@TransmissionId,@InteriorColorId,@CarModelId,@AspNetUserId)
 
   SET @CarId = SCOPE_IDENTITY()
GO



DROP PROCEDURE IF EXISTS dbo.EditCars
go
CREATE PROCEDURE EditCars
(
    @CarId int,
	@Sold bit,
	@Vin int,
	@SalesPrice int,
	@MSRP int,
	@CarYear int,
	@Mileage int,
	@Special bit,
	@Photo nvarchar(300),
	@Discription varchar(400),
	@BodyStyleId int,
    @ColorId int,
    @CarTypeId int,
	@TransmissionId int,
	@InteriorColorId int,
	@CarModelId int,
	@AspNetUserId nvarchar(128)
)
AS  
    UPDATE Cars SET Sold=@Sold,
	AspNetUserId=@AspNetUserId,
	Vin=@Vin,
	SalesPrice=@SalesPrice,
	MSRP=@MSRP, 
	CarYear=@CarYear,
	Mileage=@Mileage,
	Special=@Special, 
	Photo=@Photo, 
	Discription=@Discription,
	BodyStyleId=@BodyStyleId,
	ColorId=@ColorId,
	CarTypeId=@CarTypeId,
	TransmissionId=TransmissionId,
	InteriorColorId=@InteriorColorId,
	CarModelId=@CarModelId 
	
	
	WHERE Cars.CarId=@CarId;

   Go


DROP PROCEDURE IF EXISTS dbo.GetByMake
go

CREATE PROCEDURE GetByMake(@id int)
AS
select * 
from Cars
where Cars.CarModelId=@id

GO
DROP PROCEDURE IF EXISTS dbo.GetByModel
go

CREATE PROCEDURE GetByModel(@id int)
AS
select * 
from Cars
inner join CarModel on Cars.CarModelId=CarModel.CarModelId
where Cars.CarModelId=@id

GO


DROP PROCEDURE IF EXISTS dbo.GetByPrice
go

CREATE PROCEDURE GetByPrice(@low int, @high int)
AS
select * 
from Cars
where Cars.SalesPrice>@low AND Cars.SalesPrice<@high
GO

DROP PROCEDURE IF EXISTS dbo.GetByYear
go

CREATE PROCEDURE GetByYear(@year int)
AS
select * 
from Cars
where Cars.CarYear = @year
GO

DROP PROCEDURE IF EXISTS dbo.GetAllCars
go

CREATE PROCEDURE GetAllCars
AS
select * 
from Cars
GO

DROP PROCEDURE IF EXISTS dbo.GetCars
go

CREATE PROCEDURE GetCars(@Id int)
AS
select *
from Cars
where CarId=@Id
GO

DROP PROCEDURE IF EXISTS dbo.RemoveCars
go

CREATE PROCEDURE RemoveCars(@Id int)
AS
delete
from Cars
where Cars.CarId=@Id

Go
DROP PROCEDURE IF EXISTS dbo.GetAllSpecial
go

CREATE PROCEDURE GetAllSpecial
AS
select *
from Cars
where Special = 1
GO


DROP PROCEDURE IF EXISTS dbo.GetAllSold
go
CREATE PROCEDURE GetAllSold
AS
select *
from Cars
where Sold = 1
GO

DROP PROCEDURE IF EXISTS dbo.GetAllNew
go
CREATE PROCEDURE GetAllNew
AS
select *
from Cars
where CarTypeId = 2
GO

DROP PROCEDURE IF EXISTS dbo.GetAllUsed
go
CREATE PROCEDURE GetAllUsed
AS
select *
from Cars
where CarTypeId = 1
GO

DROP PROCEDURE IF EXISTS dbo.MarkSpecial
go

CREATE PROCEDURE MarkSpecial(@Id int)
AS
UPDATE Cars SET Special=1 WHERE Cars.CarId=@Id;
GO

DROP PROCEDURE IF EXISTS dbo.MarkSold
go

CREATE PROCEDURE MarkSold(@Id int)
AS
UPDATE Cars SET Sold=1 WHERE Cars.CarId=@Id;
GO
