CREATE PROCEDURE [dbo].[UpdateGameProcedure]
	@id INT,
	@title VARCHAR(100),
	@date INT,
	@summary NVARCHAR(4000),
	@status INT,
	@rating INT
AS
	UPDATE Games
	SET Title = @title, ReleaseDate = @date, Summary = @summary, Status = @status, Rating = @rating
	WHERE Id = @id;
RETURN 0
