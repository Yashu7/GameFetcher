CREATE PROCEDURE [dbo].[RemoveGame]
	@id int
	
AS
	DELETE FROM Games WHERE Id = @id;
RETURN 0
