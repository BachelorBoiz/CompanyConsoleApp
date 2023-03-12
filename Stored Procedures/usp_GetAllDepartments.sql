USE [Company]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetAllDepartments]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DNumber, DName, MgrSSN, MgrStartDate,
	(SELECT COUNT(SSN) FROM Employee WHERE Employee.Dno = Department.DNumber) AS 'EmpCount'
	FROM Department
END
GO


