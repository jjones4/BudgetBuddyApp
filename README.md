# BudgetBuddyApp Overview

The BudgetBuddy App is a C# WPF .NET 6.0 app for keeping personal budgets. It has a MSSQL Server backend and associated stored procedures for performing CRUD operations on the user names, the budgets, and the budget line items.

Multiple users can add their user names to the database, and each user can have multiple budgets associated with their user name.

For example, a user "abrown" can have two budgets: Personal and Business.

The only stipulation is that user names must be unique in the database.

# Getting Started with BudgetBuddy

To use BudgetBuddy, you can build and run the solution using Microsoft Visual Studio.

You must have a MSSQL Server database with appropriate tables and stored procedures in order to use the full features of the app.

The appsettings.json file has a connection string which assumes the existence of a database called "BudgetBuddy." You must add your server name to the connection string in order for it to function.

Once you create the database, you can run the dbo.spInitializeData to set up all the necessary tables, including the Foreign Key constraints and some sample users, budgets, and line items.

Then, you can add all the stored procedures to the database, and you can begin using BudgetBuddy!
