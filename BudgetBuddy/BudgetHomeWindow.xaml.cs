using BudgetLibrary;
using BudgetLibrary.DataLayer;
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
        private DateTime startDate = new DateTime(1, 1, 1);
        private DateTime endDate = new DateTime(2999, 12, 31);

        public BudgetHomeWindow()
        {
            InitializeComponent();

            PopulateUserBudgetTitles();

            FillOutBudgetTable(startDate, endDate);
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
            CreateTransactionsWindow createTransaction = new CreateTransactionsWindow(this, startDate, endDate);
            createTransaction.Show();
        }

        private void PopulateUserBudgetTitles()
        {
            welcomeTextBlock.Text =
                ((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text;

            budgetNameTextBlock.Text = ((MainWindow)Application.Current.MainWindow).selectedBudgetComboBox.Text;
        }

        public void FillOutBudgetTable(DateTime startDate, DateTime endDate)
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
                if (transaction.DateOfTransaction >= startDate && transaction.DateOfTransaction < endDate)
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
            }

            budgetTable.ItemsSource = budgetTableRowData;
        }

        private void editTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidBudgetId())
            {
                int lineItemId;
                int.TryParse(budgetIdToEditTextBox.Text, out lineItemId);

                EditOrRemoveLineItemWindow editOrRemoveLinteItem = new EditOrRemoveLineItemWindow(lineItemId, this, startDate, endDate);

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

        private void filterMonthButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime todaysDate = DateTime.Today;

            startDate = new DateTime(todaysDate.Year, todaysDate.Month, 1);
            endDate = startDate.AddMonths(1);

            FillOutBudgetTable(startDate, endDate);
        }

        private void filterYearButton_Click(object sender, RoutedEventArgs e)
        {
            int year = DateTime.Now.Year;

            startDate = new DateTime(year, 1, 1);
            endDate = new DateTime(year, 12, 31);

            FillOutBudgetTable(startDate, endDate);
        }

        private void filterNoneButton_Click(object sender, RoutedEventArgs e)
        {
            startDate = new DateTime(1, 1, 1);
            endDate = new DateTime(2999, 12, 31);

            FillOutBudgetTable(startDate, endDate);
        }

        private void budgetSummaryButton_Click(object sender, RoutedEventArgs e)
        {
            SqlData data = new SqlData(config);

            List<TransactionModel> budget =
                data.GetAllUserBudgetLineItems(((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text,
                ((MainWindow)Application.Current.MainWindow).selectedBudgetComboBox.Text);

            List<List<string>> budgetSummaryTableRowData = new List<List<string>>();

            int counter = 1;
            budgetSummaryTableRowData.Add(new List<string>
            {
                "Budget Summary",
                "",
                "",
                ""
            });

            budgetSummaryTableRowData.Add(new List<string>
            {
                "Month",
                "Credits",
                "Debits",
                "Margin"
            });

            foreach (List<string> summaryRow in BudgetSummaryLogic.BuildSummaryTable(budget))
            {
                budgetSummaryTableRowData.Add(summaryRow);
            }

            //foreach (var transaction in budget)
            //{
            //    budgetSummaryTableRowData.Add(new List<string>());

            //    for (int i = 0; i < 4; i++)
            //    {
            //        if (i == 0)
            //        {
            //            budgetSummaryTableRowData[counter].Add(transaction.Id.ToString());
            //        }
            //        if (i == 1)
            //        {
            //            budgetSummaryTableRowData[counter].Add(transaction.DateOfTransaction.Date.ToShortDateString().ToString());
            //        }
            //        if (i == 2)
            //        {
            //            budgetSummaryTableRowData[counter].Add(Convert.ToDecimal(string.Format("{0:0.00}",
            //                transaction.AmountOfTransaction)).ToString());
            //        }
            //        if (i == 3)
            //        {
            //            budgetSummaryTableRowData[counter].Add(transaction.DescriptionOfTransaction.ToString());
            //        }
            //    }

            //    counter += 1;
            //}

            budgetTable.ItemsSource = budgetSummaryTableRowData;
        }
    }
}
