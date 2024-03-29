USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spLineItems_UpdateLineItemById]    Script Date: 7/23/2022 5:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLineItems_UpdateLineItemById] 
	-- Add the parameters for the stored procedure here
	@LineItemId int,
	@TransactionDate datetime2,
	@TransactionAmount money,
	@TransactionDescription nvarchar(255),
	@CreditOrDebit int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[LineItems]
	SET TransactionDate = @TransactionDate, TransactionAmount = @TransactionAmount,
	TransactionDescription = @TransactionDescription, CreditDebit = @CreditOrDebit, IsLarge = 0
	WHERE Id = @LineItemId;

END
