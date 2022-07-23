# BudgetBuddyApp Overview

The BudgetBuddy App is a C# WPF .NET 6.0 app for keeping personal budgets. It has a MSSQL Server backend and associated stored procedures for performing CRUD operations on the app users, their budgets, and their budget line items.

Multiple users can add their user names to the database, and each user can have multiple budgets associated with their user names.

For example, a user, abrown, can have two budgets: Personal and Business.

The only stipulations are: user names must be unique in the database, and each user cannot have two budgets with the same name.

# Getting Started with BudgetBuddy

To use BudgetBuddy, you need a MSSQL Server database with appropriate tables and stored procedures in order to use the full features of the app.

First, you can run the following SQL statement to create the database:

- CREATE DATABASE BudgetBuddy;

Next, locate the appsettings.json file in the BudgetBuddy folder. Ensure you type in your correct server name instead of the placeholder data.

Then, locate the stored procedure, dbo.spInitializeData, in the Stored Procedures folder.

Create and Execute the dbo.spInitializeData stored procedure to set up all the necessary tables, including the Foreign Key constraints and some sample users, budgets, and line items to play with.

From the Stored Procedures folder, create the rest of the stored procedures in the database.

Finally, you can build and run the solution using Microsoft Visual Studio!
