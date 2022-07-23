﻿using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for BudgetHomeWindow.xaml
    /// </summary>
    public partial class BudgetHomeWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        public BudgetHomeWindow()
        {
            InitializeComponent();

            PopulateUserBudgetTitles();

            FillOutBudgetTable();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createNewTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTransactionsWindow createTransaction = new CreateTransactionsWindow(this);
            createTransaction.Show();
        }

        private void settingsLink_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }

        private void PopulateUserBudgetTitles()
        {
            welcomeTextBlock.Text =
                ((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text;

            budgetNameTextBlock.Text = ((MainWindow)Application.Current.MainWindow).selectedBudgetComboBox.Text;
        }

        public void FillOutBudgetTable()
        {
            SqlData data = new SqlData(config);

            List<TransactionModel> budget =
                data.GetAllUserBudgetLineItems(((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text,
                ((MainWindow)Application.Current.MainWindow).selectedBudgetComboBox.Text);

            List<List<string>> budgetTableRowData = new List<List<string>>();

            int counter = 1;
            budgetTableRowData.Add(new List<string>
            {
                "Id",
                "Date",
                "Amount",
                "Description",
                "Credit/Debit"
            });

            foreach (var transaction in budget)
            {
                budgetTableRowData.Add(new List<string>());

                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        budgetTableRowData[counter].Add(transaction.Id.ToString());
                    }
                    if (i == 1)
                    {
                        budgetTableRowData[counter].Add(transaction.DateOfTransaction.Date.ToShortDateString().ToString());
                    }
                    if (i == 2)
                    {
                        budgetTableRowData[counter].Add(Convert.ToDecimal(string.Format("{0:0.00}",
                            transaction.AmountOfTransaction)).ToString());
                    }
                    if (i == 3)
                    {
                        budgetTableRowData[counter].Add(transaction.DescriptionOfTransaction.ToString());
                    }
                    if (i == 4)
                    {
                        budgetTableRowData[counter].Add(transaction.CreditOrDebit.ToString());
                    }
                }

                counter += 1;
            }

            budgetTable.ItemsSource = budgetTableRowData;
        }

        private void editTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidBudgetId())
            {
                int lineItemId;
                int.TryParse(budgetIdToEditTextBox.Text, out lineItemId);

                EditOrRemoveLineItemWindow editOrRemoveLinteItem = new EditOrRemoveLineItemWindow(lineItemId, this);

                editOrRemoveLinteItem.Show();
            }
            else
            {
                MessageBox.Show("Please enter a valid budget Id number.", "ID Error");
            }
        }

        private bool IsValidBudgetId()
        {
            bool output = true;
            int budgetId;
            bool idMatchFound = false;

            if (int.TryParse(budgetIdToEditTextBox.Text, out budgetId) == false)
            {
                output = false;
            }
            else
            {
                // Check to make sure the id entered by the user matches an id in THEIR selected budget
                // and not any of the other budgets
                SqlData data = new SqlData(config);
                int lineItemId;

                List<TransactionModel> budget =
                    data.GetAllUserBudgetLineItems(welcomeTextBlock.Text, budgetNameTextBlock.Text);

                foreach (TransactionModel lineItem in budget)
                {
                    lineItemId = lineItem.Id;

                    if (budgetId == lineItemId)
                    {
                        idMatchFound = true;
                    }
                }
            }

            if (idMatchFound == false)
            {
                output = false;
            }

            return output;
        }
    }
}
