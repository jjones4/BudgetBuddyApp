USE [BudgetBuddy]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spLineItems_AddNewLineItem 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@BudgetName nvarchar(100),
	@TransactionDate datetime2,
	@TransactionAmount money,
	@TransactionDescription nvarchar(255),
	@IsCreditOrDebit int

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
	WHERE BudgetName = @BudgetName
	AND UsersId = @UserId;

	INSERT INTO [dbo].[LineItems]
	(TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, BudgetsId)
	VALUES
	(@TransactionDate, @TransactionAmount, @TransactionDescription, @IsCreditOrDebit, 0, @BudgetId);


END
GO
