CREATE TABLE Users(
		Id INT IDENTITY (1,1) UNIQUE,
		Username VARCHAR (30) NOT NULL,
		Password VARCHAR (26) NOT NULL,
		ProfilePicture VARBINARY CHECK(DATALENGTH(ProfilePicture)<900*1024),
		LastLoginTime DATE,
		IsDeleted NVARCHAR(5) NOT NULL CHECK(IsDeleted='true' OR IsDeleted='false')
		)

INSERT INTO Users(Username,Password,ProfilePicture,LastLoginTime,IsDeleted)
VALUES
('Gosho','12345',34,NULL,'true'),
('Pesho','123456',23,NULL,'true'),
('Sasho','1234567',34,NULL,'true'),
('Mariq','12345678',25,NULL,'true'),
('Ivana','123456789',56,NULL,'true')

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id,Username);

ALTER TABLE Users
ADD CONSTRAINT PASSWORD CHECK(LEN(Password)>=5);

ALTER TABLE Users DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Person PRIMARY KEY(Id);

ALTER TABLE Users
ADD CONSTRAINT UC_Users UNIQUE(Username);

ALTER TABLE Users
ADD CONSTRAINT CHK_Users CHECK(LEN(Password) >=3);