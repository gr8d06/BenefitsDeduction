-- Server=localhost;Database=master;Trusted_Connection=True;

--Setup Policy table
USE [Benefits]
GO

IF OBJECT_ID('Policy') IS NULL
BEGIN
CREATE TABLE [Policy] (
	Id				INT IDENTITY(1,1) PRIMARY KEY,
	IsActive		BIT NOT NULL DEFAULT 1,
	[Description]	NVARCHAR(100) NOT NULL,
	PrimaryPrice	FLOAT NOT NULL,
	DependantPrice	FLOAT NOT NULL
);
END;

--Setup Policy Sprocs
	--Create
	USE [Benefits]
	GO
	
	DROP PROCEDURE IF EXISTS dbo.InsertPolicy;
	GO

	CREATE PROCEDURE InsertPolicy
		@IsActive BIT, @Description NVARCHAR(100), @PrimaryPrice FLOAT, @DependantPrice FLOAT
	AS
	BEGIN;
		
		IF NOT EXISTS(SELECT 1 FROM Policy WHERE [Description] = @Description)
		BEGIN
			INSERT INTO Policy (IsActive, [Description], PrimaryPrice, DependantPrice)
			VALUES	(@IsActive, @Description, @PrimaryPrice, @DependantPrice)
		END;

	END;
	GO

	--READ ALL
	
	USE [Benefits]
	GO

	DROP PROCEDURE IF EXISTS dbo.SelectAllPolicies;
	GO

	CREATE PROCEDURE SelectAllPolicies		
	AS
	BEGIN;
		
		SELECT Id, IsActive, [Description], PrimaryPrice, DependantPrice
		FROM dbo.Policy;
		
	END;
	GO


	--DELETE

	USE [Benefits]
	GO

	DROP PROCEDURE IF EXISTS dbo.DeletePolicy;
	GO

	CREATE PROCEDURE DeletePolicy
		@Id INT
	AS
	BEGIN;
		
		DELETE FROM Policy WHERE Id = @Id;

	END;
	GO



--Seed Policy Data
IF NOT EXISTS(SELECT 1 FROM [Policy] WHERE [Description] = 'A Demo Policy')
BEGIN
	EXEC InsertPolicy @IsActive= true, @Description= 'A Demo Policy', @PrimaryPrice= 1000.00, @DependantPrice= 500.00
END;



/*-------------------------------------------------*/



-- Setup Enrolle Table

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
		Relation		NVARCHAR(50),
		[Address]		NVARCHAR(256) NOT NULL,
		PolicyId		INT NOT NULL,
		PayCheckDeduction		FLOAT
	);
END;


-- Enrolle Sprocs

	--INSERT
	USE [Benefits]
	GO

	DROP PROCEDURE IF EXISTS dbo.InsertEnrollee;
	GO

	CREATE PROCEDURE InsertEnrollee 
	@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @IsActiveAccount BIT, @IsPrimary BIT, @StartDate DATE, @PrimaryId INT, @Address NVARCHAR(256), @PolicyId INT, @Relation NVARCHAR(50), @PayCheckDeduction FLOAT
	AS
	BEGIN;
		
		IF NOT EXISTS(SELECT 1 FROM Enrollee WHERE FirstName = @FirstName AND LastName = @LastName AND [Address] = @Address)
		BEGIN
			INSERT INTO Enrollee (FirstName, LastName, IsActiveAccount, IsPrimary, StartDate, PrimaryId, [Address], PolicyId, Relation, PayCheckDeduction)
			VALUES	(@FirstName, @LastName, @IsActiveAccount, @IsPrimary, @StartDate, @PrimaryId, @Address, @PolicyId, @Relation, @PayCheckDeduction)
		END;

	END;
	GO

	--SELECT All
	USE [Benefits]
	GO

	DROP PROCEDURE IF EXISTS dbo.SelectAllEnrollees;
	GO

	CREATE PROCEDURE SelectAllEnrollees 
	AS
	BEGIN;
		
		SELECT [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[IsActiveAccount]
		  ,[IsPrimary]
		  ,[StartDate]
		  ,[PrimaryId]
		  ,[Relation]
		  ,[Address]
		  ,[PolicyId]
		  ,[PayCheckDeduction]
	  FROM [Benefits].[dbo].[Enrollee]

	END;
	GO

	--SELECT BY ID
	USE [Benefits]
	GO
	
	DROP PROCEDURE IF EXISTS dbo.SelectEnrolleeById;
	GO

	CREATE PROCEDURE SelectEnrolleeById 
	@Id INT
	AS
	BEGIN;
		
		SELECT TOP 1 [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[IsActiveAccount]
		  ,[IsPrimary]
		  ,[StartDate]
		  ,[PrimaryId]
		  ,[Relation]
		  ,[Address]
		  ,[PolicyId]
		  ,[PayCheckDeduction]
	  FROM [Benefits].[dbo].[Enrollee]
	  WHERE Id = @Id;

	END;
	GO
	
	--DELETE BY ID
	USE [Benefits]
	GO
	
	DROP PROCEDURE IF EXISTS dbo.DeleteEnrolleeById;
	GO

	CREATE PROCEDURE DeleteEnrolleeById 
	@Id INT
	AS
	BEGIN;
		DELETE  FROM [Benefits].[dbo].[Enrollee]  WHERE Id = @Id;
	END;
	GO

--Seed Enrollee Data

IF NOT EXISTS(SELECT 1 FROM Enrollee WHERE FirstName IN ('Alex','Aardvark'))
BEGIN
	DECLARE @tmpDate DATE;
	SELECT @tmpDate = GETDATE();
		EXEC dbo.InsertEnrollee @FirstName = 'Alex',     @LastName = 'Dane', @IsActiveAccount = 1, @IsPrimary = 1, @StartDate = @tmpDate, @PrimaryId = 0, @Address = '5457 S 700 E Whitestown IN, 46075', @PolicyId = 1, @Relation = 'Primary', @PayCheckDeduction = 34.62;
		EXEC dbo.InsertEnrollee @FirstName = 'Aardvark', @LastName = 'Dane', @IsActiveAccount = 1, @IsPrimary = 0, @StartDate = @tmpDate, @PrimaryId = 1, @Address = '5457 S 700 E Whitestown IN, 46075', @PolicyId = 1, @Relation = 'Child', @PayCheckDeduction = 17.31;
		EXEC dbo.InsertEnrollee @FirstName = 'Baboon',   @LastName = 'Dane', @IsActiveAccount = 1, @IsPrimary = 0, @StartDate = @tmpDate, @PrimaryId = 1, @Address = '5457 S 700 E Whitestown IN, 46075', @PolicyId = 1, @Relation = 'Child', @PayCheckDeduction = 19.23;
END;



/*-------------------------------------------------*/


SELECT * FROM Enrollee;
SELECT * FROM [Policy];


