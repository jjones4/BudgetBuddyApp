## BudgetBuddyApp Overview

BudgetBuddyApp is a C# WPF .NET 6.0 app for keeping personal budgets. It has a MSSQL backend. In the Stored Procedures folder, I have included the necessary stored procedures for performing the app's CRUD operations on the app's users, their budgets, and their budget line items.

Multiple users can add their user names to the database, and each user can have multiple budgets.

The only stipulations are: user names must be unique in the database, and each user cannot have two budgets with the same name.

## Getting Started with BudgetBuddyApp

To use BudgetBuddy, you need a MSSQL database with appropriate tables and stored procedures in order to use the full features of the app.

First, execute the following SQL statement to create the database:

- CREATE DATABASE BudgetBuddy;

Next, locate the appsettings.json file in the BudgetBuddy folder. Ensure you type in your correct server name instead of the placeholder data.

Then, locate the stored procedure, dbo.spInitializeData, in the Stored Procedures folder. Create and execute the dbo.spInitializeData stored procedure to set up all the necessary tables, including the Foreign Key constraints and some sample users, budgets, and line items to play with.

From the Stored Procedures folder, create the rest of the stored procedures in the database.

Finally, you can build and run the solution using Microsoft Visual Studio!
