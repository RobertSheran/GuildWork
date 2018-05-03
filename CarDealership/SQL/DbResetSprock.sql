
USE CarDatabase
GO

DROP PROCEDURE IF EXISTS SetUpTestValues
GO

CREATE PROCEDURE SetUpTestValues AS
BEGIN
DELETE FROM Cars
DELETE FROM Transmission
DELETE FROM CarModel
DELETE FROM Make
DELETE FROM InteriorColors
DELETE FROM Contact
DELETE FROM Colors
DELETE FROM CarType
DELETE FROM BodyStyle
DELETE FROM Cars
delete from Specials
delete from Invoice
delete from States
delete from Financing


SET IDENTITY_INSERT States ON;
INSERT INTO States (StatId, StateName)
VALUES (1, 'MN'), (2, 'NY'), (3, 'OH')
SET IDENTITY_INSERT States OFF;


SET IDENTITY_INSERT Transmission on;
INSERT INTO Transmission (TransmissionId, TransmissionName)
VALUES 
(1,'Manual Transmission'), 
(2,'Fully Automatic Transmission'), 
(3,'Semi-Automatic Transmission'), 
(4,'Continuously Variable Transmission')
SET IDENTITY_INSERT Transmission off;

SET IDENTITY_INSERT Make ON;
INSERT INTO Make (MakeId, MakeName)
VALUES (1, 'Jeep'), (2, 'SUBARU'), (3, 'TOYOTA')
SET IDENTITY_INSERT Make OFF;


SET IDENTITY_INSERT Financing ON;
INSERT INTO Financing(Id, FinancingType)
VALUES (1, 'Cash'), (2, 'Card'), (3, 'Dealer Financed')
SET IDENTITY_INSERT Financing OFF;

SET IDENTITY_INSERT Invoice ON;
INSERT INTO Invoice (InvoiceId, City,ZipCode,Email,PerchaseType,InvoiceName,Phone,Price,StreetOne,StreetTwo,InvoiceState)
VALUES (1,'mpls','55555','bob@bob.com','cash','bob','9999999999',19999,'willmatt hill','wfwefwef','MN')

SET IDENTITY_INSERT Invoice OFF;

SET IDENTITY_INSERT InteriorColors ON;
INSERT INTO InteriorColors (InteriorColorId, InteriorColorName)
VALUES 
(1,'NEON GREEN'),
(2,'NEON PINK'),
(3,'NEON YELLOW')
SET IDENTITY_INSERT InteriorColors OFF;

SET IDENTITY_INSERT Contact ON;
INSERT INTO Contact (ContactId, ContactName, ContactMessage )
VALUES 
(1,'Girl','This is a message from Girl'),
(2,'Boy','This is a message from Boy'),
(3, 'Computer', 'This is a message from Computer')
SET IDENTITY_INSERT Contact OFF;

SET IDENTITY_INSERT Colors ON;
INSERT INTO Colors (ColorId, ColorName)
VALUES 
(1,'BLACK'),
(2,'WHITE'),
(3,'CHAMELEON')
SET IDENTITY_INSERT Colors OFF;

SET IDENTITY_INSERT CarType ON;
INSERT INTO CarType (CarTypeId, CarTypeName)
VALUES 
(1,'Used'),
(2,'New')
SET IDENTITY_INSERT CarType OFF;

SET IDENTITY_INSERT CarModel ON;
INSERT INTO CarModel (CarModelId, CarModelName, MakeId)
VALUES 
(1,'Liberty', 1),
(2,'Patriot',1),
(3,'Renegade',1),
(4,'Outback', 2),
(5,'Legacy',2),
(6,'Forester',2),
(7,'RAV4', 3),
(8,'Camry',3),
(9,'Yaris',3)
SET IDENTITY_INSERT CarModel OFF;

SET IDENTITY_INSERT BodyStyle ON;
INSERT INTO BodyStyle(BodyStyleId, BodyStyleName)
VALUES 
(1,'Space Wagon'),
(2,'Limousine'),
(3,'Brougham')
SET IDENTITY_INSERT BodyStyle OFF;

INSERT INTO Specials(SpecialMessage)
VALUES 
('"The essence of understanding capitalism is to recognize that the interest is not in the survival of particular capitalists, but of the system of capitalism. The most sclerotic economies are those where there never are any shakeouts; there never is any competitive pressure where failure is not a possibility. While shakeouts are painful, they set the stage for redeployment of resources for more productive uses in the future." — Lawrence Summers '),
('"[Hickel:] Karl Marxs key error is the idea that capitalism develops according to laws, that these laws are described by the tendency of the profit rate to drop, and that in the long run the system must collapse. This hypothesis has proven to be wrong, because capitalism has repeatedly found new ways of dealing with its crises. Through this inevitability of capitalism, Marx underestimates the need for political shaping..." — Paul Nolte '),
('"It is impossible for capitalism to survive, primarily because the system of capitalism needs some blood to suck. Capitalism used to be like an eagle, but now it is more like a vulture. It used to be strong enough to go and suck anybodys blood whether they were strong or not. But now it has become more cowardly, like the vulture, and it can only suck the blood of the helpless. As the nations of the world free themselves..." — Malcolm X ')

SET IDENTITY_INSERT Cars ON;
INSERT INTO Cars(CarId, AspNetUserId, CarModelId,CarTypeId,CarYear,Mileage,SalesPrice,Special,TransmissionId, Discription,BodyStyleId,ColorId,InteriorColorId,MSRP,Vin,Photo)
VALUES 
(1,null,1,1,1993,0,5000,1,1,'"I am using exactly the same clubs, other than No. 4. I was brainwashed into believing it would be abnormal with all the changes. But we are hitting the same club Jack Nicklaus did. I remember Jack hitting 5-iron on No. 11. The greens were not as fast, but the fairways were lousy." — Gary Player',1,1,1,5000,11111,'1200px-2003_Jeep_Cherokee_(KJ_MY03)_Limited_Edition_wagon_(2015-07-09)_01.jpg'),
(2,null,4,2,2018,0,12000,1,2,'"When you get into a pack of cars, then you feel the problem worst, handicapping the driver and handicapping our ability to race. When there is a crosswind, the cars suffer badly as well, which makes them even more difficult to control. They are always fun to drive, but motor ..." — Damon Hill',2,2,2,12000,22222,'BBIeWLr.jpg'),
(3,null,7,1,2010,30000,40000,1,3,'"The way I look at it is when you present the car for inspection, if I put the height (measurement) stick on there and it is too high, and there is enough time for me to take a picture with a camera, it is too high, ... I do not care what else happens.. .. If I was racing against..." — Greg Biffle ',3,3,3,40000,3333,'IMG_3111.jpg'),
(4,null,1,1,1993,0,5000,1,1,'"I am using exactly the same clubs, other than No. 4. I was brainwashed into believing it would be abnormal with all the changes. But we are hitting the same club Jack Nicklaus did. I remember Jack hitting 5-iron on No. 11. The greens were not as fast, but the fairways were lousy." — Gary Player',1,1,1,5000,11111,'1200px-2003_Jeep_Cherokee_(KJ_MY03)_Limited_Edition_wagon_(2015-07-09)_01.jpg'),
(5,null,4,2,2018,0,12000,1,2,'"When you get into a pack of cars, then you feel the problem worst, handicapping the driver and handicapping our ability to race. When there is a crosswind, the cars suffer badly as well, which makes them even more difficult to control. They are always fun to drive, but motor ..." — Damon Hill',2,2,2,12000,22222,'BBIeWLr.jpg'),
(6,null,7,1,2010,20000,40000,1,3,'"The way I look at it is when you present the car for inspection, if I put the height (measurement) stick on there and it is too high, and there is enough time for me to take a picture with a camera, it is too high, ... I do not care what else happens.. .. If I was racing against..." — Greg Biffle ',3,3,3,40000,3333,'IMG_3111.jpg')

SET IDENTITY_INSERT Cars OFF;



END

