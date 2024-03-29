USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spTemplateLines_GetTemplateLinesByUserTemplate]    Script Date: 7/21/2022 6:31:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spTemplateLines_GetTemplateLinesByUserTemplate] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@TemplateName nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @TemplateId int;

	SELECT @TemplateId = t.Id
	FROM [dbo].[Templates] t
	INNER JOIN [dbo].[Users] u ON t.UsersId = u.Id
	WHERE u.UserName = @UserName AND t.TemplateName = @TemplateName;

	SELECT Id, TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, TemplatesId
	FROM [dbo].[TemplateLines]
	WHERE TemplatesId = @TemplateId;

END
