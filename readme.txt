3000Ft/accommodation

reservation status can be:
closed - the guest checked out
reserved - active reservation
deleted - the guest cancelled

A szoba elérhető, ha kiválasztott firstReservedDay és a lastReservedDay intervallumban nincs foglalás aminek a státusza reserved


//Statisztika
Az időszakos szűrésnél vizsgálni kell a foglalás kicsekkolás időpontja benne van-e a szűrt intervallumban, majd azoknak a foglalásoknak a végössszegét össszeadni


CREATE TABLE RegisteredGuest(
 	guestId int PRIMARY KEY AUTO_INCREMENT,
    	guestCode varchar(50) not null,
	registrationDate datetime DEFAULT CURRENT_DATE,
	guestName varchar(100) not null,
	birthDay date not null,
	country varchar(50) not null,
	postalCode varchar(10) not null,
	city varchar(100) NOT null,
	address varchar(200) not null,
	email varchar(100) UNIQUE DEFAULT null,
	vip boolean DEFAULT false,
	banned boolean DEFAULT false
);

Room(
	roomId int PRIMARY KEY AUTO_INCREMENT,
	roomNumber varchar(10) not null,
 	accommodation int not null,
 	price int not null
);

Reservation(
	 reservationId INT PRIMARY KEY AUTO_INCREMENT,
	 checkedIn datetime DEFAULT null,
	 checkedOut datetime DEFAULT null,
	 guestId int not null, 
	 roomId int not null,
	 dateOfReservation datetime DEFAULT CURRENT_TIMESTAMP,
	 firstReservedDay date not null,
	 lastReservedDay date not null,
     	 reservationStatust varchar(20) DEFAULT "reserved",
	 FOREIGN KEY (guestId) REFERENCES RegisteredGuest(guestId),
	 FOREIGN KEY (roomId) REFERENCES Room(roomId)
 );