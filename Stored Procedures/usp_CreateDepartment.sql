USE [Company]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_CreateDepartment] 
	-- Add the parameters for the stored procedure here
	@DName nvarchar(50),
	@mgrSSN numeric

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM Department WHERE Department.DName = @DName)
		THROW 50001, 'Department name already in use', 1
	IF EXISTS (SELECT 1 FROM Department WHERE Department.MgrSSN = @mgrSSN)
		THROW 50001, 'MgrSSN already in use', 1

	INSERT INTO Department (DName, MgrSSN, MgrStartDate)
	VALUES (@DName, @mgrSSN, GETDATE())
    
	return SCOPE_IDENTITY()
END
GO


