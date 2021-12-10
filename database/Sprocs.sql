USE [Benefits]
GO

DROP PROCEDURE IF EXISTS dbo.InsertEnrollee;
GO

CREATE PROCEDURE InsertEnrollee 
@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @IsActiveAccount BIT, @IsPrimary BIT, @StartDate DATE, @PrimaryId INT, @Address NVARCHAR(50), @PolicyId INT, @Relation NVARCHAR(50)
AS
BEGIN;
	
	IF NOT EXISTS(SELECT 1 FROM Enrollee WHERE FirstName = @FirstName AND LastName = @LastName AND [Address] = @Address)
	BEGIN
		INSERT INTO Enrollee (FirstName, LastName, IsActiveAccount, IsPrimary, StartDate, PrimaryId, [Address], PolicyId, Relation)
		VALUES	(@FirstName, @LastName, @IsActiveAccount, @IsPrimary, @StartDate, @PrimaryId, @Address, @PolicyId, @Relation)
	END;

END;
GO

/*-------------------------------------------------*/

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
  FROM [Benefits].[dbo].[Enrollee]

END;
GO


/*-------------------------------------------------*/


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
  FROM [Benefits].[dbo].[Enrollee]
  WHERE Id = @Id;

END;
GO

EXEC SelectEnrolleeById @Id = 1


/*-------------------------------------------------*/

DROP PROCEDURE IF EXISTS dbo.DeleteEnrolleeById;

GO

CREATE PROCEDURE DeleteEnrolleeById 
@Id INT
AS
BEGIN;
	DELETE  FROM [Benefits].[dbo].[Enrollee]  WHERE Id = @Id;
END;
GO

/*-------------------------------------------------*/