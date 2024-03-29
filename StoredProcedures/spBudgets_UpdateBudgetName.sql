USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spBudgets_UpdateBudgetName]    Script Date: 7/21/2022 6:30:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBudgets_UpdateBudgetName] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@BudgetName nvarchar(100),
	@OldBudgetName nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @UserId int;
	DECLARE @BudgetId int;

	SELECT @UserId = Id
	FROM [dbo].[Users]
	WHERE UserName = @UserName;

	SELECT @BudgetId = Id
	FROM [dbo].[Budgets]
	WHERE BudgetName = @OldBudgetName
	AND UsersId = @UserId;

	UPDATE [dbo].[Budgets]
	SET BudgetName = @BudgetName
	WHERE Id = @BudgetId;

END
