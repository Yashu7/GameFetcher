CREATE PROCEDURE [dbo].[GamePlatformJunction]
	@gameID INT,
	@platformID INT
AS
	
	
	
	
	INSERT GamePlatforms
	(
	GameId,
	PlatformId
	)
	VALUES
	(
	(SELECT MAX(Id) FROM Games),
	@platformID
	)
RETURN 0
