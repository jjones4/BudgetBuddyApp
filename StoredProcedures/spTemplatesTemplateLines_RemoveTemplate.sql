USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spTemplatesTemplateLines_RemoveTemplate]    Script Date: 7/21/2022 6:32:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spTemplatesTemplateLines_RemoveTemplate]

	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@TemplateName nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @UserId int;
	DECLARE @TemplateId int;

	SELECT @UserId = Id
	FROM [dbo].[Users]
	WHERE UserName = @UserName;

	SELECT @TemplateId = Id
	FROM [dbo].[Templates]
	WHERE TemplateName = @TemplateName
	AND UsersId = @UserId;

	DELETE
	FROM [dbo].[TemplateLines]
	WHERE TemplatesId = @TemplateId;

	DELETE
	FROM [dbo].[Templates]
	WHERE Id = @TemplateId;

END
