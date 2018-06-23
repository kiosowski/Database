CREATE TABLE Majors (
	MajorID INT IDENTITY,
	[Name] VARCHAR(50) NOT NULL

	CONSTRAINT PK_Majors PRIMARY KEY (MajorID)
)

CREATE TABLE Students (
	StudentID INT IDENTITY,
	StudentNumber NVARCHAR(50) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT NOT NULL

	CONSTRAINT PK_Students PRIMARY KEY (StudentID)

	CONSTRAINT FK_Students FOREIGN KEY (MajorID) REFERENCES Majors (MajorID)
)

CREATE TABLE Payments (
	PaymentID INT IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT NOT NULL

	CONSTRAINT PK_Payments PRIMARY KEY (PaymentID)

	CONSTRAINT FK_Payments FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT IDENTITY,
	SubjectName VARCHAR(50) NOT NULL

	CONSTRAINT PK_Subjects PRIMARY KEY (SubjectID)
)

CREATE TABLE Agenda (
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL

	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)

	CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
	CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID)
)
