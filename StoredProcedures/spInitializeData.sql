USE [BudgetBuddy]
GO
/****** Object:  StoredProcedure [dbo].[spInitializeData]    Script Date: 8/4/2022 8:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInitializeData]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DROP TABLE IF EXISTS [dbo].[TemplateLines];
	DROP TABLE IF EXISTS [dbo].[Templates];
	DROP TABLE IF EXISTS [dbo].[LineItems];
	DROP TABLE IF EXISTS [dbo].[Budgets];
	DROP TABLE IF EXISTS [dbo].[Users];
	
	CREATE TABLE [dbo].[Users]
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		UserName nvarchar(50) NOT NULL
	);

	-- Insert statements for procedure here
	INSERT INTO [dbo].[Users] (UserName)
	VALUES
	('abrown'),
	('bclayton'),
	('cduvall');

	DECLARE @UsersId1 int;
	DECLARE @UsersId2 int;
	DECLARE @UsersId3 int;

	SELECT @UsersId1 = Id FROM dbo.Users WHERE UserName = 'abrown';
	SELECT @UsersId2 = Id FROM dbo.Users WHERE UserName = 'bclayton';
	SELECT @UsersId3 = Id FROM dbo.Users WHERE UserName = 'cduvall';

	CREATE TABLE [dbo].[Budgets]
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		BudgetName nvarchar(100) NOT NULL,
		UsersId int NOT NULL,
		CONSTRAINT [FK_Budgets_Users] FOREIGN KEY (UsersId) REFERENCES Users (Id)
	);

	INSERT INTO [dbo].[Budgets] (BudgetName, UsersId)
	VALUES
	('Personal', @UsersId1),
	('Business', @UsersId1),
	('Personal', @UsersId2),
	('Family', @UsersId2),
	('Personal', @UsersId3);

	CREATE TABLE [dbo].[Templates]
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		TemplateName nvarchar(100) NOT NULL,
		UsersId int NOT NULL,
		CONSTRAINT [FK_Templates_Users] FOREIGN KEY (UsersId) REFERENCES Users (Id)
	);

	INSERT INTO [dbo].[Templates] (TemplateName, UsersId)
	VALUES
	('Rent', @UsersId1),
	('Deductions', @UsersId1),
	('Rent', @UsersId2),
	('Eating Out', @UsersId3);

	DECLARE @BudgetsId1 int;
	DECLARE @BudgetsId2 int;
	DECLARE @BudgetsId3 int;
	DECLARE @BudgetsId4 int;
	DECLARE @BudgetsId5 int;

	SELECT @BudgetsId1 = Id FROM dbo.Budgets WHERE BudgetName = 'Personal' AND UsersId = 1;
	SELECT @BudgetsId2 = Id FROM dbo.Budgets WHERE BudgetName = 'Business' AND UsersId = 1;
	SELECT @BudgetsId3 = Id FROM dbo.Budgets WHERE BudgetName = 'Personal' AND UsersId = 2;
	SELECT @BudgetsId4 = Id FROM dbo.Budgets WHERE BudgetName = 'Family' AND UsersId = 2;
	SELECT @BudgetsId5 = Id FROM dbo.Budgets WHERE BudgetName = 'Personal' AND UsersId = 3;

	CREATE TABLE [dbo].[LineItems]
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		TransactionDate datetime2 NOT NULL,
		TransactionAmount money NOT NULL,
		TransactionDescription nvarchar(255) NOT NULL,
		CreditDebit int NOT NULL,
		IsLarge bit NOT NULL,
		BudgetsId int NOT NULL,
		CONSTRAINT [FK_LineItems_Budgets] FOREIGN KEY (BudgetsId) REFERENCES Budgets (Id)
	);

	INSERT INTO [dbo].[LineItems] (TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, BudgetsId)
	VALUES
	('20211231', 750, 'Paycheck', 1, 0, @BudgetsId1),
	('20220604', 750, 'Paycheck', 1, 0, @BudgetsId1),
	('20220604', 1250, 'Paycheck', 1, 0, @BudgetsId2),
	('20220801', 20, 'Gas', -1, 0, @BudgetsId1),
	('20220803', 75.23, 'Groceries', -1, 0, @BudgetsId1),
	('20220604', 50, 'Groceries', -1, 0, @BudgetsId3),
	('20220831', 100, 'Power', -1, 0, @BudgetsId1),
	('20220611', 90, 'Internet', -1, 0, @BudgetsId5),
	('20220901', 750, 'Paycheck', 1, 0, @BudgetsId1),
	('20220607', 300, 'Car Payment', -1, 0, @BudgetsId3),
	('20230101', 80, 'Internet', -1, 0, @BudgetsId1),
	('20220608', 150, 'Power', -1, 0, @BudgetsId4),
	('20220604', 52.25, 'Eating Out', -1, 0, @BudgetsId2);

	DECLARE @TemplatesId1 int;
	DECLARE @TemplatesId2 int;
	DECLARE @TemplatesId3 int;
	DECLARE @TemplatesId4 int;

	SELECT @TemplatesId1 = Id FROM dbo.Templates WHERE TemplateName = 'Rent' AND UsersId = 1;
	SELECT @TemplatesId2 = Id FROM dbo.Templates WHERE TemplateName = 'Deductions' AND UsersId = 1;
	SELECT @TemplatesId3 = Id FROM dbo.Templates WHERE TemplateName = 'Rent' AND UsersId = 2;
	SELECT @TemplatesId4 = Id FROM dbo.Templates WHERE TemplateName = 'Eating Out' AND UsersId = 3;

	CREATE TABLE [dbo].[TemplateLines]
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		TransactionDate datetime2 NULL,
		TransactionAmount money NULL,
		TransactionDescription nvarchar(255) NULL,
		CreditDebit int NULL,
		IsLarge bit NULL,
		TemplatesId int NOT NULL,
		CONSTRAINT [FK_TemplateLines_Templates] FOREIGN KEY (TemplatesId) REFERENCES Templates (Id)
	);

	INSERT INTO [dbo].[TemplateLines] (TransactionDate, TransactionAmount, TransactionDescription, CreditDebit, IsLarge, TemplatesId)
	VALUES
	(NULL, 1004.41, 'Rent', -1, 0, @TemplatesId1),
	(NULL, 67.52, 'Health Insurance', -1, 0, @TemplatesId2),
	(NULL, 25, 'Trash', -1, 0, @TemplatesId1),
	(NULL, 15, 'Fees', -1, 0, @TemplatesId1),
	(NULL, NULL, 'Federal Taxes', -1, 0, @TemplatesId2),
	(NULL, 1250.50, 'Rent', -1, 0, @TemplatesId3),
	(NULL, NULL, 'Food', -1, 0, @TemplatesId4),
	(NULL, 25, 'Water', -1, 0, @TemplatesId1),
	(NULL, 27.12, 'Fees', -1, 0, @TemplatesId3),
	(NULL, NULL, 'Drinks', -1, 0, @TemplatesId4),
	(NULL, NULL, 'Tip', -1, 0, @TemplatesId4);

END
