USE [Company]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateDepartmentName] 
	-- Add the parameters for the stored procedure here
	@DNumber numeric,
	@DName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM Department WHERE Department.DName = @DName)
		THROW 50001, 'Department name already in use', 1

	UPDATE Department
	SET DName = @DName
	WHERE DNumber = @DNumber
END
GO


