CREATE TABLE [dbo].[GamePlatforms]
(
	
    [GameId] INT NOT NULL,
	[PlatformId] INT NOT NULL,
	CONSTRAINT PK_GamePlatforms PRIMARY KEY
	(
		GameId,
		PlatformId
	),
	FOREIGN KEY (GameId) REFERENCES Games (Id)  ON DELETE CASCADE,
	FOREIGN KEY (PlatformId) REFERENCES Platforms (PlatformID)

)
