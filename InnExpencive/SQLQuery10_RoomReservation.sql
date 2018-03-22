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