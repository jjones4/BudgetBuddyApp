USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spLineItems_GetLineItemsByUserBudget]    Script Date: 7/21/2022 6:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLineItems_GetLineItemsByUserBudget] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@BudgetName nvarchar (100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @BudgetId int;

	SELECT @BudgetId = b.Id
	FROM [dbo].[Budgets] b
	INNER JOIN [dbo].[Users] u ON b.UsersId = u.Id
	WHERE u.UserName = @UserName AND b.BudgetName = @BudgetName;

	SELECT Id, TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, BudgetsId
	FROM [dbo].[LineItems]
	WHERE BudgetsId = @BudgetId;

END
