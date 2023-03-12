USE [Company]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetDepartment] 
	-- Add the parameters for the stored procedure here
	@DNumber numeric
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DNumber, DName, MgrSSN, MgrStartDate,
(SELECT COUNT(SSN) FROM Employee LEFT JOIN Department d ON Employee.Dno = d.DNumber WHERE d.DNumber = @DNumber) AS 'EmpCount'
FROM Department
WHERE Department.DNumber = @DNumber
END
GO


