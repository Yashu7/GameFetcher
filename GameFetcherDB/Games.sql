 CREATE TABLE [dbo].[Games]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR (100) NOT NULL,
	ReleaseDate INT,
	Summary NVARCHAR (4000),
	Rating INT DEFAULT 0,
	PlatformPlaying NVARCHAR(50) DEFAULT 'Pick Platform',
	Status INT NOT NULL DEFAULT 0,
	CONSTRAINT fk_PlayingStatus FOREIGN KEY (Status) REFERENCES PlayingStatus (id)
)
