SELECT Games.Title, Platforms.PlatformName FROM ((Games INNER JOIN GamePlatforms ON Games.Id = GamePlatforms.GameId) INNER JOIN Platforms ON GamePlatforms.PlatformId = Platforms.PlatformID);
