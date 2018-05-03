USE master
GO
if exists (select * from sysdatabases where name='CarDatabase')
		drop database CarDatabase
go

create database CarDatabase
go

USE CarDatabase;

create table ContactForm(
	ContactId int identity(1,1) primary key not null,
    ContactMessage varchar(600) not null)

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
	Make varchar(20) not null
	)
	
create table CarModel(
	CarModelId int identity(1,1) primary key not null,
	CarModelName varchar(20),
	MakeId int not null foreign key references Make(MakeId)
	)


create table Transmission(
	TransmissionId int identity(1,1) primary key not null,
	TransmissionName varchar(20) not null)

create table CarType(
	CarTypeId int identity(1,1) primary key not null,
	CarTypeName varchar(20) not null)


create table Cars(
	CarId int identity(1,1) primary key not null,
	Vin int not null,
	SalesPrice int not null,
	MSRP int not null,
	CarYear int not null,
	Mileage int not null,
	Special bit not null,
	Photo image not null,
	Discription varchar(400) not null,

	BodyStyleId int not null foreign key references BodyStyle(BodyStyleId),
    ColorId int not null foreign key references Colors(ColorId),
    CarTypeId int not null foreign key references CarType(CarTypeId),
	TransmissionId int not null foreign key references Transmission(TransmissionId),
	InteriorColorId int not null foreign key references InteriorColors(InteriorColorId),
	CarModelId int not null foreign key references CarModel(CarModelId),
)


create table Contact(
ContactId int identity(1,1) primary key not null,
	ContactName varchar(50) not null,
	Phone varchar(30) null,
	Email varchar(50) null,
	ContactMessage varchar(400) not null,
)


