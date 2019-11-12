USE master
GO
IF EXISTS(SELECT * FROM sys.sysdatabases WHERE name='module5a')
DROP DATABASE module5a
GO
CREATE DATABASE module5a
GO
USE module5a
GO
CREATE TABLE Roles
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(25)
)
GO
CREATE TABLE CabinTypes
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(25)
)
CREATE TABLE Countries
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(25)
)
CREATE TABLE Aircrafts(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(25),
	MakeModel NVARCHAR(25),
	TotalSeats INT,
	EconomySeats INT,
	BusinessSeats INT
)
CREATE TABLE Offices(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	CountryID INT CONSTRAINT fk_Offices_Countries FOREIGN KEY(CountryID) REFERENCES dbo.Countries(ID),
	Title NVARCHAR(25),
	Phone NVARCHAR(25),
	Contact NVARCHAR(25)
)
GO
CREATE TABLE Users(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	RoleID INT CONSTRAINT fk_Users_Roles FOREIGN KEY(RoleID) REFERENCES dbo.Roles(ID),
	OfficeID INT CONSTRAINT fk_Users_Offices FOREIGN KEY(OfficeID) REFERENCES dbo.Offices(ID),
	Email NVARCHAR(25),
	Password NVARCHAR(50),
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	BirthDate DATETIME,
	Active BIT
)
GO
CREATE TABLE Airport(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	CountryID INT CONSTRAINT fk_Country_Airport FOREIGN KEY(CountryID) REFERENCES dbo.Countries(ID),
	IATACode NVARCHAR(25),
	Name NVARCHAR(25)
)
GO
CREATE TABLE Routes(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	DepartureAirportID INT CONSTRAINT fk_Dep_Air FOREIGN KEY(DepartureAirportID) REFERENCES dbo.Airport(ID),
	ArrivalAirportID INT CONSTRAINT fk_Arr_Air FOREIGN KEY(ArrivalAirportID) REFERENCES dbo.Airport(ID),
	Distance FLOAT,
	FlightTime TIME
)
GO
CREATE TABLE Schedules(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Date DATE,
	Time TIME,
	AircraftID INT CONSTRAINT fk_Schedules_Aircrafts FOREIGN KEY(AircraftID) REFERENCES dbo.Aircrafts(ID),
	RouteID INT CONSTRAINT fk_Schedules_Routes FOREIGN KEY(RouteID) REFERENCES dbo.Routes(ID),
	FlightNumber NVARCHAR(25),
	EconomyPrice MONEY,
	Confirmed BIT
)
GO
CREATE TABLE Tickets
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	UserID INT CONSTRAINT fk_Tickets_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(ID),
	ScheduleID INT CONSTRAINT fk_Tickets_Schedules FOREIGN KEY (ScheduleID) REFERENCES dbo.Schedules(ID),
	CabinType INT CONSTRAINT fk_Tickets_CabinTypes FOREIGN KEY (CabinType) REFERENCES dbo.CabinTypes(ID),
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Phone NVARCHAR(25),
	PassportNumber NVARCHAR(25),
	PassportCountry INT CONSTRAINT fk_Tickets_Countries FOREIGN KEY (PassportCountry) REFERENCES dbo.Countries(ID),
	BookingReference NVARCHAR(25),
	Confirm BIT
)
CREATE TABLE Amenities
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	AmenService NVARCHAR(25),
	Price FLOAT 
)
CREATE TABLE AmenitiesCabinType
(
	AmenitiesID INT,
	CabinTypeID INT,
	PRIMARY KEY (AmenitiesID,CabinTypeID),
	FOREIGN KEY (AmenitiesID) REFERENCES dbo.Amenities(ID),
	FOREIGN KEY (CabinTypeID) REFERENCES dbo.CabinTypes(ID)
)

CREATE TABLE AmenitiesTickets
(
	AmenitiesID INT,
	TicketID INT,
	Price FLOAT,
	PRIMARY KEY (AmenitiesID,TicketID),
	FOREIGN KEY (AmenitiesID) REFERENCES dbo.Amenities(ID),
	FOREIGN KEY (TicketID) REFERENCES dbo.Tickets(ID)
)
//----------//



GO
INSERT dbo.Roles VALUES('administrator')
INSERT dbo.Roles VALUES('user')

GO
SELECT * FROM dbo.Roles
GO

INSERT dbo.Countries VALUES( 'VIETNAM')
INSERT dbo.Countries VALUES( 'UNITED STATE OF AMERICA')
INSERT dbo.Countries VALUES('CHINA ')
INSERT dbo.Countries VALUES('HONG KONG')
INSERT dbo.Countries VALUES('SWITZERLAND')
INSERT dbo.Countries VALUES('IRAN')
INSERT dbo.Countries VALUES('KOREA')
INSERT dbo.Countries VALUES('MALAYSIA')
INSERT dbo.Countries VALUES('THAILAND')
INSERT dbo.Countries VALUES('JAPAN')
INSERT dbo.Countries VALUES('ITALIA')
INSERT dbo.Countries VALUES('FRANCE')
SELECT * FROM dbo.Countries
GO
INSERT INTO dbo.Aircrafts VALUES('Boeing-733', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('Boeing-792', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('Boeing-758', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('An-22', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('An-24', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('Boeing-710', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('Boeing-910', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('MH-370', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('MH-311', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('Airbus A320', 'Airbus', 250, 200, 50)
INSERT INTO dbo.Aircrafts VALUES('Airbus A344', 'Airbus', 250, 200, 50)
INSERT INTO dbo.Aircrafts VALUES('An-2', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('MH-329', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('MH-443', 'Boeing', 200, 140, 60)
SELECT * FROM dbo.Aircrafts
GO

INSERT dbo.Airport VALUES(1, 'NB', N'Nội Bài') 
INSERT dbo.Airport VALUES(1, 'TSN', N'Tân Sơn Nhất')
INSERT dbo.Airport VALUES(11, 'LND', N'Leonardo')
INSERT dbo.Airport VALUES(12, 'RSY', N'Roissy')
INSERT dbo.Airport VALUES(3, 'BEZ', N'Bắc Kinh')
INSERT dbo.Airport VALUES(8, 'KUL', N' Kuala Lumpur')
INSERT dbo.Airport VALUES(9, 'BKK', N'Suvarnabhumi')
INSERT dbo.Airport VALUES(10, 'HND', N'Haneda')
INSERT dbo.Airport VALUES(4, 'HKG', N'Hồng Kông')
INSERT dbo.Airport VALUES(5, 'ZRH', N'Zurich')
INSERT dbo.Airport VALUES(6, 'SYZ', N'Shiraz ')
INSERT dbo.Airport VALUES(2, 'ATL', N'Hartsfield Jackson Atlanta')
INSERT dbo.Airport VALUES(2, 'ORD', N'O-Hare')
INSERT dbo.Airport VALUES(7, 'CJJ', N'Cheongju')
SELECT * FROM dbo.Airport INNER JOIN dbo.Countries ON Countries.ID = Airport.CountryID
GO
INSERT INTO dbo.Routes VALUES(10, 11, 7000, '8:25:00')
INSERT INTO dbo.Routes VALUES(9, 8, 8000, '10:00:00')
INSERT INTO dbo.Routes VALUES(3, 10, 12500, '16:00:00')
INSERT INTO dbo.Routes VALUES(4, 3, 14000, '17:00:00')
INSERT INTO dbo.Routes VALUES(6, 9, 12000, '14:00:00')
INSERT INTO dbo.Routes VALUES(5, 4, 4000, '5:25:00')
INSERT INTO dbo.Routes VALUES(13, 3, 7000, '8:25:00')
INSERT INTO dbo.Routes VALUES(11, 7, 6000, '7:25:00')
INSERT INTO dbo.Routes VALUES(2, 3, 4000, '5:25:00')
INSERT INTO dbo.Routes VALUES(1, 4, 22500, '18:00:00')
INSERT INTO dbo.Routes VALUES(1, 12, 18000, '15:20:00')

GO
SELECT * FROM dbo.Routes
GO
GO
INSERT dbo.Schedules VALUES('01-01-2011', '11:20:00', 1, 7, '109-203-011', 240, 0)
INSERT dbo.Schedules VALUES('02-10-2019', '12:10:00', 3, 6, '201-001-872', 210, 0)
INSERT dbo.Schedules VALUES('05-20-2019', '12:40:00', 5, 6, '576-091-201', 240, 0)
INSERT dbo.Schedules VALUES('11-10-2019', '12:00:00', 4, 3, '111-231-210', 210, 1)
INSERT dbo.Schedules VALUES('11-10-2019', '09:00:00', 7, 2, '320-381', 210, 1)
INSERT dbo.Schedules VALUES('03-10-2019', '05:40:00', 8, 2, '122-129', 225, 0)
INSERT dbo.Schedules VALUES('01-10-2019', '08:25:00', 2, 10, '122-129', 225, 0)
INSERT dbo.Schedules VALUES('07-12-2019', '06:00:00', 3, 9, '321-019', 225, 1)
INSERT dbo.Schedules VALUES('10-10-2019', '03:00:00', 9, 8, '321-019', 225, 1)
INSERT dbo.Schedules VALUES('12-08-2019', '08:00:00', 10, 5, '201-211-256', 250, 1)
INSERT dbo.Schedules VALUES('10-11-2019', '07:00:00', 13, 4, '551-092-322-118', 210, 1)
INSERT dbo.Schedules VALUES('04-08-2019', '04:00:00', 11, 7, '322', 240, 1)
INSERT dbo.Schedules VALUES('03-10-2019', '03:00:00', 12, 6, '102-908', 240, 1)


SELECT * FROM dbo.Schedules
GO

INSERT dbo.Offices VALUES(4, N'Kirama', '29892911', 'anomic@kirama.com')
INSERT dbo.Offices VALUES(3, N'Kirama', '29892911', 'anomic@kirama.com')
INSERT dbo.Offices VALUES(6, N'Kirama', '29892911', 'anomic@kirama.com')
INSERT dbo.Offices VALUES(5, N'Singthon', '9892229', 'anomic@singthon.com')
INSERT dbo.Offices VALUES(7, N'Rote', '8928881', 'anomic@rote.com')
INSERT dbo.Offices VALUES(2, N'Kamoric', '8519282', 'anomic@amoric.com')
INSERT dbo.Offices VALUES(1, N'Doha', '19003210', 'anomic@doha.com')

GO
SELECT * FROM dbo.Offices
GO
INSERT dbo.Users VALUES(1, 6, N'kanuts@gmail.com', N'p11002',N'Harik', N'Shingk', '08-12-1985', 0)
INSERT dbo.Users VALUES(2, 7, N'karits@gmail.com', N'p09201',N'Shit', N'Mary', '04-19-1980', 0)
INSERT dbo.Users VALUES(2, 7, N'karibe@gmail.com', N'p10922',N'Mish', N'Karibe', '07-23-1992', 1)
INSERT dbo.Users VALUES(1, 7, N'rotage@gmail.com', N'p09211',N'Cristia', N'Makup', '07-11-1990', 1)
INSERT dbo.Users VALUES(1, 6, N'resocdj@gmail.com', N'p41234',N'Taca', N'Shimit', '06-12-1998', 1)
INSERT dbo.Users VALUES(2, 2, N'poteca@gmail.com', N'p28111',N'Hany', N'Lemmi', '06-12-1997', 1)
INSERT dbo.Users VALUES(1, 5, N'grandsing@gmail.com', N'p98211',N'Deviln', N'Rocoh', '06-13-1992', 1)
INSERT dbo.Users VALUES(1, 2, N'john_9@gmail.com', N'p29822',N'Bakam', N'John', '10-14-1997', 1)
INSERT dbo.Users VALUES(1, 6, N'admin', N'admin',N'Harik', N'Shingk', '08-12-1985', 0)

SELECT * FROM dbo.Users WHERE Users.Email = 'admin' AND Users.Password = 'admin'

INSERT dbo.CabinTypes VALUES(1)
INSERT dbo.CabinTypes VALUES(2)
INSERT dbo.CabinTypes VALUES(3)
INSERT dbo.CabinTypes VALUES(4)

SELECT * FROM CabinTypes

INSERT INTO dbo.Amenities VALUES('BEER',20)
INSERT INTO dbo.Amenities VALUES('LIVE AT 35',35)
INSERT INTO dbo.Amenities VALUES('DIRECT TV',50)
INSERT INTO dbo.Amenities VALUES('SLPPER',45)
INSERT INTO dbo.Amenities VALUES('DONT DISTURB',10)
INSERT INTO dbo.Amenities VALUES('TURKISH COFFEE',15)
INSERT INTO dbo.Amenities VALUES('SEAT-TO-SEAT CHAR',30)
INSERT INTO dbo.Amenities VALUES('PLAYING CARD',50)

SELECT * FROM Amenities

INSERT INTO AmenitiesCabinType VALUES(1,1)
INSERT INTO AmenitiesCabinType VALUES(2,1)
INSERT INTO AmenitiesCabinType VALUES(3,1)
INSERT INTO AmenitiesCabinType VALUES(4,1)
INSERT INTO AmenitiesCabinType VALUES(5,1)
INSERT INTO AmenitiesCabinType VALUES(1,2)
INSERT INTO AmenitiesCabinType VALUES(2,2)
INSERT INTO AmenitiesCabinType VALUES(3,2)
INSERT INTO AmenitiesCabinType VALUES(4,2)
INSERT INTO AmenitiesCabinType VALUES(1,3)
INSERT INTO AmenitiesCabinType VALUES(5,3)
INSERT INTO AmenitiesCabinType VALUES(8,3)
INSERT INTO AmenitiesCabinType VALUES(1,4)
INSERT INTO AmenitiesCabinType VALUES(2,4)
INSERT INTO AmenitiesCabinType VALUES(8,4)
INSERT INTO AmenitiesCabinType VALUES(7,4)
INSERT INTO AmenitiesCabinType VALUES(6,4)

SELECT * FROM AmenitiesCabinType

SELECT ID FROM Users where Email = 'admin' AND Password = 'admin'
SELECT * FROM dbo.Users
SELECT * FROM dbo.Schedules
SELECT * FROM dbo.CabinTypes
SELECT * FROM dbo.Countries

INSERT INTO Tickets VALUES(2,2,1,'John','Wick','0123456789','11111111',1,'01',1)
INSERT INTO Tickets VALUES(2,3,2,'Deviln','Rocoh','0123456789','22222222',3,'02',0)
INSERT INTO Tickets VALUES(4,3,1,'Deviln','Rocoh','0123456789','33333333',5,'03',1)
INSERT INTO Tickets VALUES(4,4,3,'Hany','Lemmi','0123456789','44444444',1,'04',1)
INSERT INTO Tickets VALUES(5,4,4,'Taca','Shimit','0123456789','55555555',1,'05',0)
INSERT INTO Tickets VALUES(6,11,1,'Cristia','Makup','0123456789','66666666',3,'06',1)
INSERT INTO Tickets VALUES(7,2,3,'Mish','Karibe','0123456789','77777777',5,'07',1)
INSERT INTO Tickets VALUES(8,4,2,'Shit','Mary','0123456789','88888888',7,'08',0)
INSERT INTO Tickets VALUES(9,2,4,'Harik','Shingk','0123456789','99999999',6,'09',1)

DELETE FROM Tickets
SELECT * FROM Tickets

SELECT * FROM Amenities
SELECT * FROM Tickets
INSERT INTO AmenitiesTickets VALUES(1,1,20)
INSERT INTO AmenitiesTickets VALUES(2,2,35)
INSERT INTO AmenitiesTickets VALUES(3,1,50)
INSERT INTO AmenitiesTickets VALUES(1,2,20)
INSERT INTO AmenitiesTickets VALUES(2,3,35)
INSERT INTO AmenitiesTickets VALUES(3,8,50)
INSERT INTO AmenitiesTickets VALUES(4,9,45)
INSERT INTO AmenitiesTickets VALUES(1,5,20)
INSERT INTO AmenitiesTickets VALUES(2,6,35)
INSERT INTO AmenitiesTickets VALUES(3,7,50)
INSERT INTO AmenitiesTickets VALUES(4,9,45)
INSERT INTO AmenitiesTickets VALUES(5,4,10)

USE module5a
go
DELETE FROM AmenitiesTickets WHERE AmenitiesTickets.TicketID = 1
SELECT * FROM AmenitiesTickets

SELECT Tickets.FirstName,Tickets.LastName,CabinTypes.Name,Schedules.ID,Tickets.PassportNumber,Routes.DepartureAirportID,Routes.ArrivalAirportID,Schedules.Date,Schedules.Time,CabinTypes.ID AS 'CABIN_ID',Tickets.ID 
FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID
			 INNER JOIN Routes ON Schedules.RouteID = Routes.ID
			 INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID
						WHERE Tickets.BookingReference = '01'

SELECT Amenities.AmenService,Amenities.Price,AmenitiesID 
FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID
WHERE AmenitiesCabinType.CabinTypeID = 1

