CREATE PROCEDURE [dbo].[InsertPlatform]
	@Id INT,
	@Name NVARCHAR(50)
AS
	INSERT INTO Platforms
	(
	PlatformID,
	PlatformName
	)
	VALUES
	(
	@Id,
	@Name
	)
RETURN 0
