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

            List<List<string>> test = new List<List<string>>();

            int counter = 1;
            test.Add(new List<string>
            {
                "Date",
                "Amount",
                "Description",
                "Credit/Debit"
            });

            foreach (var transaction in budget)
            {
                test.Add(new List<string>());

                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        test[counter].Add(transaction.DateOfTransaction.Date.ToShortDateString().ToString());
                    }
                    if (i == 1)
                    {
                        test[counter].Add(Convert.ToDecimal(string.Format("{0:0.00}",
                            transaction.AmountOfTransaction)).ToString());
                    }
                    if (i == 2)
                    {
                        test[counter].Add(transaction.DescriptionOfTransaction.ToString());
                    }
                    if (i == 3)
                    {
                        test[counter].Add(transaction.CreditOrDebit.ToString());
                    }
                }

                counter += 1;
            }

            budgetTable.ItemsSource = test;
        }
    }
}
