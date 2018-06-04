CREATE TABLE People(
	Id INT IDENTITY (1,1) UNIQUE,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY CHECK(DATALENGTH(Picture)<900*1024),
	Height DECIMAL(10,2),
	Weight DECIMAL(10,2),
	Gender VARCHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
	Birthdate INT NOT NULL,
	Biography NVARCHAR(255)
	)

INSERT INTO People (Name,Picture,Height,Weight,Gender,Birthdate,Biography)
VALUES
('Kolio',NULL,2,155,'m',22,'captain'),
('Stamat',NULL,1.5,120,'m',15,'Kon'),
('Mariq',NULL,1.70,60,'f',23,'Driver'),
('Pesho',NULL,1.80,95,'m',22,'Worker'),
('Vulcho',NULL,1.20,56,'m',45,'Pensioner')
