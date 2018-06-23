CREATE TABLE Manufacturers(
	ManufacturerID INT IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
	CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
	)

CREATE TABLE Models(
	ModelID INT IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL

	CONSTRAINT PK_Models PRIMARY KEY(ModelID)
	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
	)

INSERT INTO Manufacturers(Name,EstablishedOn) VALUES
		('BMW','07/03/1916'),
		('Tesla','07/03/2003'),
		('Lada','07/03/1966')

INSERT INTO Models(Name,ManufacturerID) VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)