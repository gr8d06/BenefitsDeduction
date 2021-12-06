USE [Benefits]
GO

IF OBJECT_ID('Address') IS NULL
BEGIN
CREATE TABLE [Address] (
	Id		INT IDENTITY(1,1) PRIMARY KEY,
	Street1 NVARCHAR(50) NOT NULL,
	Street2 NVARCHAR(50) NOT NULL DEFAULT '',
	City	NVARCHAR(50) NOT NULL,
	Zip		NVARCHAR(10) NOT NULL,
	[State] NVARCHAR(50) NOT NULL,
	Country NVARCHAR(50) NOT NULL
);
END;
/* Could create another table with "previous addresses" to have a historical recor upon change or multiple residences.  */

--Seed Data
IF NOT EXISTS(SELECT 1 FROM [Address] WHERE Street1 = '5457 S 700 E')
BEGIN
	INSERT INTO [Address] (Street1, City, Zip, [State], Country)
	Values ('5457 S 700 E', 'Whitestown', 'IN', '46075', 'United States');
END;


IF OBJECT_ID('Policy') IS NULL
BEGIN
CREATE TABLE [Policy] (
	Id				INT IDENTITY(1,1) PRIMARY KEY,
	Active			BIT NOT NULL DEFAULT 1,
	[Description]	NVARCHAR(100) NOT NULL,
	PrimaryPrice	FLOAT NOT NULL,
	DependantPrice	FLOAT NOT NULL
);
END;

--Seed Data
IF NOT EXISTS(SELECT 1 FROM [Policy] WHERE [Description] = 'A Demo Policy')
BEGIN
	INSERT INTO [Policy] ([Description], PrimaryPrice, DependantPrice)
	VALUES ('A Demo Policy', 1000.00, 500.00)
END;


IF OBJECT_ID('Enrollee') IS NULL
BEGIN
	CREATE TABLE Enrollee (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		FirstName		NVARCHAR(50) NOT NULL,
		LastName		NVARCHAR(50) NOT NULL,
		IsActiveAccount BIT NOT NULL DEFAULT 1,
		IsPrimary		BIT NOT NULL DEFAULT 0,
		StartDate		DATE NOT NULL DEFAULT GETDATE(),	
		PrimaryId		INT NOT NULL DEFAULT 0,
		/*FKs*/ 
		AddressId		INT NOT NULL,
		PolicyId		INT NOT NULL
	);
END;

IF NOT EXISTS(SELECT 1 FROM Enrollee WHERE FirstName IN ('Alex','Aardvark'))
BEGIN
INSERT INTO Enrollee (FirstName, LastName, IsActiveAccount, IsPrimary, StartDate, PrimaryId, AddressId, PolicyId)
VALUES	('Alex',		'Dane', 1, 1, GETDATE(), 0, 1, 1),
		('Aardvark',	'Dane', 1, 0, GETDATE(), 1, 1, 1);

		DECLARE @tmpDate DATE;
		SELECT @tmpDate = GETDATE();
		EXEC dbo.InsertEnrollee @FirstName = 'Cheetah', @LastName = 'Dane', @IsActiveAccount = 1, @IsPrimary = 0, @StartDate = @tmpDate, @PrimaryId = 1, @AddressId = 1, @PolicyId = 1;
END;



--Family View
/*
SELECT  e.FirstName, e.LastName, PrimaryId FROM Enrollee e
WHERE Id = 1 OR PrimaryId = 1
*/

/*
SELECT e.*, p.PrimaryPrice, a.Street1 FROM Enrollee e
	JOIN [Policy]	p on p.Id = e.PolicyId
	JOIN [Address]	a on a.Id = e.AddressId
WHERE	e.FirstName = 'Alex'
	AND	e.LastName = 'Dane'
*/

