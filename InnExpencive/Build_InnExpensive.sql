USE master
GO
if exists (select * from sysdatabases where name='InnExpensive')
		drop database InnExpensive
go

create database InnExpensive
go

USE InnExpensive;


CREATE TABLE Room (
   RoomID INT IDENTITY(1,1) PRIMARY KEY,
   OccupencyLimit smallint not null,
   [Floor] smallint not null,
)



CREATE TABLE Amenity (
   AmenityID INT IDENTITY(1,1) PRIMARY KEY,
   AmenityName varchar(30) not null,
   AmenityPrice decimal(6,2) not null,
)

CREATE TABLE RoomAmenity (
	
	RoomID INT NOT NULL,
	AmenityID INT NOT NULL,
	CONSTRAINT PK_RoomAmenityID
		PRIMARY KEY (RoomID, AmenityID),
	CONSTRAINT FK_Room_RoomAmenity
		FOREIGN KEY (RoomID) 
		REFERENCES Room(RoomID),
	CONSTRAINT FK_Amenity_RoomAmenity
		FOREIGN KEY (AmenityID) 
		REFERENCES Amenity(AmenityID),
)


CREATE TABLE PromoCode (
   PromoCodeID INT IDENTITY(1,1) PRIMARY KEY,
   StartDate date not null,
   EndDate date not null,
   DiscountPercent decimal(2,2) null,
   DiscountFlat decimal (6,2) null
)

CREATE TABLE Reservation (
   ReservationID INT IDENTITY(1,1) PRIMARY KEY,
   ContactName varchar(30) not null,
   ContactPhone varchar(20) NOT NULL,
   ContactEmail varchar(40) NULL,
   CheckInDate date not null,
   CheckOutDate date not null,
   PromoCodeID INT FOREIGN KEY REFERENCES PromoCode(PromoCodeID) Null
   )

CREATE TABLE Guest (
   GuestID INT IDENTITY(1,1) PRIMARY KEY,
   GuestName varchar(30) not null,
   Age smallint not null,
   ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) NOT NULL
)

CREATE TABLE RoomReservation (
	
	ReservationID INT NOT NULL,
	RoomID INT NOT NULL,
	CONSTRAINT PK_RoomReservationID
		PRIMARY KEY (RoomID, ReservationID),
	CONSTRAINT FK_Room_RoomReservation
		FOREIGN KEY (RoomID) 
		REFERENCES Room(RoomID),
	CONSTRAINT FK_Reservation_RoomReservation
		FOREIGN KEY (ReservationID) 
		REFERENCES Reservation(ReservationID),
)

CREATE TABLE Billing (
   GrandTotal decimal(8,2) NOT NULL,
   Tax decimal (4,2) Null,
   ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) PRIMARY KEY NOT NULL,
)

CREATE TABLE AddOn (
   AddOnID INT IDENTITY(1,1) PRIMARY KEY,
   AddOnName VarChar(30) not null,
)

CREATE TABLE AddOnPrice (
   AddOnPriceID INT IDENTITY(1,1) PRIMARY KEY,
   AddOnID INT FOREIGN KEY REFERENCES AddOn(AddOnID) not null,
   AddOnPrice decimal(6,2) not null,
   StartDate date not null,
   EndDate date not null,
)


CREATE TABLE Detail (
   DetailID INT IDENTITY(1,1) PRIMARY KEY,
   Discription varchar(60) NOT NULL,
   Cost decimal (6,2) NOT NULL,
   ReservationID INT FOREIGN KEY REFERENCES Billing(ReservationID) NOT NULL,
   AddOnID Int FOREIGN KEY REFERENCES AddOn(AddOnID) NOT NULL

)

create table RoomType(
   RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
   TypeDiscription VarChar(60) NOT NULL,
   RoomID INT FOREIGN KEY REFERENCES Room(RoomID) NOT NULL
)

CREATE TABLE RoomTypeRate (
   RoomTypeRateID INT IDENTITY(1,1) PRIMARY KEY,
   RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID) not null,
   RoomRate decimal(9,2) not null,
   StartDate date not null,
   EndDate date not null,
)

