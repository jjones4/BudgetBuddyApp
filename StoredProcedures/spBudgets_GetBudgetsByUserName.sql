USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spBudgets_GetBudgetsByUserName]    Script Date: 7/21/2022 6:29:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBudgets_GetBudgetsByUserName]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.Id, b.BudgetName
	FROM [dbo].[Budgets] b
	inner join
	[dbo].[Users] u on b.UsersId = u.Id
	WHERE u.UserName = @UserName;

END
