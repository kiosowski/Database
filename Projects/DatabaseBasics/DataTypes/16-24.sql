CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
);

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
);

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
);

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50),
	JobTitle NVARCHAR(50)NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
);

/*
17.BACKUP DB
*/
BACKUP DATABASE SoftUni TO DISK =  'D:\SoftuniDB-Backup.bak';

USE CarRental;

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK=  'D:\SoftuniDB-Backup.bak';

USE SoftUni

/*
18.Basic Insert
*/

INSERT INTO Towns(Name)
VALUES
(
	   'Sofia'
),
(
	   'Plovdiv'
),
(
	   'Varna'
),
(
	   'Burgas'
);

INSERT INTO Departments(Name)
VALUES
(
	   'Engineering'
),
(
	   'Sales'
),
(
	   'Marketing'
),
(
	   'Software Development'
),
(
	   'Quality Assurance'
);

INSERT INTO Employees(FirstName,
					  MiddleName,
					  LastName,
					  JobTitle,
					  DepartmentId,
					  HireDate,
					  Salary
					 )
VALUES
(
	   'Ivan',
	   'Ivanov',
	   'Ivanov',
	   '.NET Developer',
	   4,
	   CONVERT(DATE, '02/03/2004', 103),
	   3500.00
),
(
	   'Petar',
	   'Petrov',
	   'Petrov',
	   'Senior Engineer',
	   1,
	   CONVERT(DATE, '02/03/2004', 103),
	   4000.00
),
(
	   'Maria',
	   'Petrova',
	   'Ivanova',
	   'Intern',
	   5,
	   CONVERT(DATE, '28/08/2016', 103),
	   525.25
),
(
	   'Georgi',
	   'Teziev ',
	   'Ivanov',
	   'CEO',
	   2,
	   CONVERT(DATE, '09/12/2007', 103),
	   3000.00
),
(
	   'Peter',
	   'Pan ',
	   'Pan',
	   'Intern',
	   3,
	   CONVERT(DATE, '28/08/2016', 103),
	   599.88
);



/*
19.Basic Select All Fields
*/

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

/*
20.Basic Select All Fields And Order Them
*/

SELECT * FROM Towns ORDER BY NAME ASC;
SELECT * FROM Departments ORDER BY NAME ASC;
SELECT * FROM Employees ORDER BY Salary DESC;

/*
21.Basic Select Some Fields
*/

SELECT Name FROM Towns ORDER BY NAME ASC;
SELECT Name FROM Departments ORDER BY NAME ASC;
SELECT [FirstName],[LastName],[JobTitle],[Salary] 
FROM Employees ORDER BY Salary DESC;

/*
22.Increase Employees Salary
*/

UPDATE Employees
	SET Salary*=1.10;

SELECT [Salary] FROM Employees;

/*
23.Decrease Tax Rate
*/
USE Hotel
Update Payments
	SET TaxRate *=0.97;

SELECT [TaxRate] FROM Payments;

/*
24.Delete All Records
*/

TRUNCATE TABLE Occupancies;






