USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spLineItems_GetLineItemById]    Script Date: 7/23/2022 5:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLineItems_GetLineItemById] 
	-- Add the parameters for the stored procedure here
	@LineItemId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, BudgetsId
	FROM [dbo].[LineItems]
	WHERE Id = @LineItemId;

END
