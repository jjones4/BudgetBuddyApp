USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spUsers_UpdateUserName]    Script Date: 7/21/2022 6:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_UpdateUserName]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@OldUserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @UserId int;

	SELECT @UserId = Id
	FROM [dbo].[Users]
	WHERE UserName = @OldUserName;

	UPDATE [dbo].[Users]
	SET UserName = @UserName
	WHERE Id = @UserId;

END
