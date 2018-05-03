USE CarDatabase;
GO

if exists (select * from sys.tables where name='Specials')
		drop table Specials


if exists (select * from sys.tables where name='Cars')
		drop table Cars

if exists (select * from sys.tables where name='Transmission')
		drop table Transmission

if exists (select * from sys.tables where name='CarModel')
		drop table CarModel

if exists (select * from sys.tables where name='Make')
		drop table Make

if exists (select * from sys.tables where name='Colors')
		drop table Colors

if exists (select * from sys.tables where name='Contact')
		drop table Contact

if exists (select * from sys.tables where name='InteriorColors')
		drop table InteriorColors

if exists (select * from sys.tables where name='BodyStyle')
		drop table BodyStyle


if exists (select * from sys.tables where name='Cars')
		drop table Cars

if exists (select * from sys.tables where name='CarModel')
		drop table CarModel

if exists (select * from sys.tables where name='CarType')
		drop table CarType

if exists (select * from sys.tables where name='ContactForm')
		drop table ContactForm


if exists (select * from sys.tables where name='States')
		drop table States


if exists (select * from sys.tables where name='Financing')
		drop table Financing
		
if exists (select * from sys.tables where name='Invoice')
		drop table Invoice


create table Financing(
	Id int identity(1,1) primary key not null,
	FinancingType varchar(50) not null)

create table States(
	StatId int identity(1,1) primary key not null,
	StateName varchar(50) not null)

create table Invoice(
	InvoiceId int identity(1,1) primary key not null,
	InvoiceName varchar(50) not null,
	Phone varchar(50) null,
	Email varchar(50) null,
	StreetOne varchar(100) not null,
	StreetTwo varchar(100) null,
	City varchar(50) not null,
	InvoiceState varchar(20) not null,
	ZipCode varchar(20) not null,
	Price int not null,
	PerchaseType varchar(50) not null
	)	

create table BodyStyle(
	BodyStyleId int identity(1,1) primary key not null,
	BodyStyleName varchar(20) not null)


create table InteriorColors(
	InteriorColorId int identity(1,1) primary key not null,
	InteriorColorName varchar(20) not null)


create table Colors(
	ColorId int identity(1,1) primary key not null,
	ColorName varchar(20) not null)
	

create table Make(
	MakeId int identity(1,1) primary key not null,
	MakeName varchar(20) not null
	)


create table CarModel(
	CarModelId int identity(1,1) primary key not null,
	CarModelName varchar(20),
	MakeId int not null foreign key references Make(MakeId)
	)


create table Transmission(
	TransmissionId int identity(1,1) primary key not null,
	TransmissionName varchar(200) not null)

create table CarType(
	CarTypeId int identity(1,1) primary key not null,
	CarTypeName varchar(20) not null)

create table Specials(SpecialId int identity(1,1) primary key not null,
	SpecialMessage varchar(500) not null)


create table Cars(
	CarId int identity(1,1) primary key not null,
	Vin int not null,
	SalesPrice int not null,
	MSRP int not null,
	CarYear int not null,
	Mileage int not null,
	Special bit not null,
	Sold bit null,
	Photo nvarchar(128) null,
	Discription varchar(400) not null,

	BodyStyleId int not null foreign key references BodyStyle(BodyStyleId),
    ColorId int not null foreign key references Colors(ColorId),
    CarTypeId int not null foreign key references CarType(CarTypeId),
	TransmissionId int not null foreign key references Transmission(TransmissionId),
	InteriorColorId int not null foreign key references InteriorColors(InteriorColorId),
	CarModelId int not null foreign key references CarModel(CarModelId),
	AspNetUserId nvarchar(256) null foreign key references AspNetUsers(UserName),
)



create table Contact(
ContactId int identity(1,1) primary key not null,
	ContactName varchar(50) not null,
	Phone varchar(30) null,
	Email varchar(50) null,
	ContactMessage varchar(400) not null,
)

