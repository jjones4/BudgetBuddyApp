USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spUsers_AddNewUser]    Script Date: 7/21/2022 6:33:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_AddNewUser]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Users] (UserName)
	VALUES (@UserName);

END
