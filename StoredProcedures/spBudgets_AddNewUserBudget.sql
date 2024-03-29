USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spBudgets_AddNewUserBudget]    Script Date: 7/21/2022 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBudgets_AddNewUserBudget]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@BudgetName nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @UserId int;

	SELECT @UserId = Id FROM [dbo].[Users]
	WHERE UserName = @UserName;

	INSERT INTO [dbo].[Budgets] (BudgetName, UsersId)
	VALUES (@BudgetName, @UserId);
	
END
