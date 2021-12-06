USE [Benefits]
GO

DROP PROCEDURE IF EXISTS dbo.InsertEnrollee;

GO

CREATE PROCEDURE InsertEnrollee 
@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @IsActiveAccount BIT, @IsPrimary BIT, @StartDate DATE, @PrimaryId INT, @AddressId INT, @PolicyId INT
AS
BEGIN;
	
	IF NOT EXISTS(SELECT 1 FROM Enrollee WHERE FirstName = @FirstName AND LastName = @LastName AND AddressId = @AddressId)
	BEGIN
		INSERT INTO Enrollee (FirstName, LastName, IsActiveAccount, IsPrimary, StartDate, PrimaryId, AddressId, PolicyId)
		VALUES	(@FirstName, @LastName, @IsActiveAccount, @IsPrimary, @StartDate, @PrimaryId, @AddressId, @PolicyId)
	END;

END;
GO