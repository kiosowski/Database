CREATE TABLE Passports(
	PassportID INT IDENTITY(101,1),
	PassportNumber NVARCHAR(50) NOT NULL
	CONSTRAINT PK_Passports PRIMARY KEY (PassportId)
	)

CREATE TABLE Persons(
	PersonID INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT NOT NULL
	CONSTRAINT PK_Persons PRIMARY KEY(PersonID)
	CONSTRAINT FK_PersonsPassports FOREIGN KEY REFERENCES Passports(PassportID)
	)

INSERT INTO Passports(PassportNumber) VALUES
('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons(FirstName,Salary,PassportID) VALUES
('Roberto',43300,102),
	('Tom',56100,103),
	('Yana',60200,101)
