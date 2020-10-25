CREATE PROCEDURE [dbo].[InsertGame]
	
	@title VARCHAR(100),
	@date INT,
	@summary VARCHAR(250)
AS
	INSERT INTO Games
	(
	Title,
	ReleaseDate,
	Summary)
	VALUES
	(
	@title,
	@date,
	@summary)
	
RETURN 0
