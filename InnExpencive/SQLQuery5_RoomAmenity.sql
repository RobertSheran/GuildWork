USE InnExpensive;
GO

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
GO