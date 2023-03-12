SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_DeleteDepartment 
	-- Add the parameters for the stored procedure here
	@DNumber INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Department WHERE Department.DNumber = @DNumber
	UPDATE Employee
	SET Dno = NULL
	WHERE Dno = @DNumber
END
GO
