CREATE DATABASE Hotel
USE Hotel
CREATE TABLE Employees(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(50)NOT NULL,
	LastName NVARCHAR(50),
	Title NVARCHAR (50) NOT NULL,
	Notes NVARCHAR(255)
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(255),
	EmergencyNumber INT NOT NULL,
	Notes NVARCHAR (MAX),
)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(50) NOT NULL PRIMARY KEY,
	Notes NVARCHAR(MAX),
)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(50) NOT NULL PRIMARY KEY,
	Notes NVARCHAR(MAX),
)

CREATE TABLE BedTypes(
	BedType NVARCHAR(50) NOT NULL PRIMARY KEY,
	Notes NVARCHAR (MAX),
)

CREATE TABLE Rooms(
	RoomNumber INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate NVARCHAR(50),
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL,
	PaymentDate DATE,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT NOT NULL,
	AmountCharged INT NOT NULL,
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal INT NOT NULL,
	Notes NVARCHAR (MAX),
)

CREATE TABLE Occupancies(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL,
	DateOccupied DATE,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge INT,
	NOTES NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName,LastName,Title,Notes)
	Values
		('Pesho', 'Peshov', 'Software Developer',NULL),
		('Gosho', 'Peshov', 'Driver',NULL),
		('Kiro', 'Peshov', 'Musician',NULL)

INSERT INTO Customers(FirstName, LastName,PhoneNumber,EmergencyName,EmergencyNumber,Notes)
	Values
		('Pesho', 'Peshov', NULL, NULL, 112, NULL),
		('Gosho', 'Peshov', NULL, NULL, 112, NULL),
		('Kiro', 'Peshov', NULL, NULL, 112, NULL)


INSERT INTO RoomStatus (RoomStatus,Notes)
	Values
		('Free',NULL),
		('Taken',NULL),
		('Reserved',NULL)

INSERT INTO RoomTypes(RoomType,Notes)
	Values
		('Standard',NULL),
		('Apartament',NULL),
		('Small',NULL)

INSERT INTO BedTypes(BedType,Notes)
	Values
		('Double',NULL),
		('Single',NULL),
		('Extra Large',NULL)

INSERT INTO Rooms(RoomType,BedType,Rate,RoomStatus,Notes)
	Values
		('Standard','Single',NULL,'Free',NULL),
		('Apartament','Extra Large','Very good','Reserved',NULL),
		('Small','Double',NULL,'Taken',NULL)

INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal,Notes)
	Values
		(1, NULL, 2311, NULL,NULL, 7, 500, 0,0,2000,NULL),
		(3, NULL, 5456, NULL,NULL, 9, 200, 0,0,3000,NULL),
		(2, NULL, 4321, NULL,NULL, 2, 300, 0,0,5000,NULL)

INSERT INTO Occupancies(EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes)
	Values
		(911, NULL, 42, 2, NULL,NULL,NULL),
		(214, NULL, 12, 10, NULL,NULL,NULL),
		(543, NULL, 567, 52, NULL,NULL,NULL)