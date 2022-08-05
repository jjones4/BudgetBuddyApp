using BudgetLibrary.DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for CreateTransactionsWindow.xaml
    /// </summary>
    public partial class CreateTransactionsWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();
        private BudgetHomeWindow _budgetHome = new BudgetHomeWindow();

        public CreateTransactionsWindow(BudgetHomeWindow budgetHome)
        {
            InitializeComponent();

            _budgetHome = budgetHome;

            userNameTextBlock.Text = _budgetHome.welcomeTextBlock.Text;
            budgetNameTextBlock.Text = _budgetHome.budgetNameTextBlock.Text;
        }

        private void saveNewTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            List<bool> validationResults = new List<bool>();

            validationResults = TransactionValidationResults();
            bool finalValidationResults = true;
            
            foreach (bool result in validationResults)
            {
                if (result == false)
                {
                    finalValidationResults = false;
                }
            }

            if (finalValidationResults == true)
            {
                SqlData data = new SqlData(config);

                decimal transactionAmount = 0;
                int creditOrDebit = 0;

                DateTime parsedDateTime;

                string[] dateFormats = {    "M/d/yyyy",
                                        "M/dd/yyyy",
                                        "MM/d/yyyy",
                                        "MM/dd/yyyy" };

                DateTime.TryParseExact(transactionDateTextBox.Text, dateFormats, new CultureInfo("en-US"),
                    System.Globalization.DateTimeStyles.None, out parsedDateTime);

                decimal.TryParse(transactionAmountTextBox.Text, out transactionAmount);

                int.TryParse(creditOrDebitTextBox.Text, out creditOrDebit);

                data.CreateNewLineItem(userNameTextBlock.Text, budgetNameTextBlock.Text, parsedDateTime, 
                    transactionAmount, transactionDescriptionTextBox.Text, creditOrDebit);

                _budgetHome.FillOutBudgetTable(new DateTime(1901, 1, 1), new DateTime(2099, 12, 31));

                MessageBox.Show("Transaction Added Successfully", "Transaction Added");
                this.Close();
            }
            else
            {
                // Date, Amount, Description, CreditOrDebit

                // 0000, 0001, 0010, 0011
                if (validationResults[0] == false && validationResults[1] == false &&
                    validationResults[2] == false && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid date, amount, description, and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == false &&
                    validationResults[2] == false && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid date, amount, and description entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == false &&
                    validationResults[2] == true && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid date, amount, and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == false &&
                    validationResults[2] == true && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid date and amount entered.", "Transaction Error");
                }

                // 0100, 0101, 0110, 0111
                if (validationResults[0] == false && validationResults[1] == true &&
                    validationResults[2] == false && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid date, description, and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == true &&
                    validationResults[2] == false && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid date and description entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == true &&
                    validationResults[2] == true && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid date and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == false && validationResults[1] == true &&
                    validationResults[2] == true && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid date entered.", "Transaction Error");
                }

                // 1000, 1001, 1010, 1011
                if (validationResults[0] == true && validationResults[1] == false &&
                    validationResults[2] == false && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid amount, description, and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == true && validationResults[1] == false &&
                    validationResults[2] == false && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid amount and description entered.", "Transaction Error");
                }
                if (validationResults[0] == true && validationResults[1] == false &&
                    validationResults[2] == true && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid amount and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == true && validationResults[1] == false &&
                    validationResults[2] == true && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid amount entered.", "Transaction Error");
                }

                // 1100, 1101, 1110, 1111
                if (validationResults[0] == true && validationResults[1] == true &&
                    validationResults[2] == false && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid description and credit/debit entered.", "Transaction Error");
                }
                if (validationResults[0] == true && validationResults[1] == true &&
                    validationResults[2] == false && validationResults[3] == true)
                {
                    MessageBox.Show("Invalid description entered.", "Transaction Error");
                }
                if (validationResults[0] == true && validationResults[1] == true &&
                    validationResults[2] == true && validationResults[3] == false)
                {
                    MessageBox.Show("Invalid credit/debit entered.", "Transaction Error");
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private List<bool> TransactionValidationResults()
        {
            List<bool> validationResults = new List<bool>();

            bool isValidDate = true;
            bool isValidAmount = true;
            bool isValidDescription = true;
            bool isValidCreditOrDebit = true;

            validationResults.Add(isValidDate);
            validationResults.Add(isValidAmount);
            validationResults.Add(isValidDescription);
            validationResults.Add(isValidCreditOrDebit);

            if (IsValidDate() == false)
            {
                validationResults[0] = false;
            }

            if (IsValidAmount() == false)
            {
                validationResults[1] = false;
            }

            if (IsValidDescription() == false)
            {
                validationResults[2] = false;
            }
            
            if (IsValidCreditOrDebit() == false)
            {
                validationResults[3] = false;
            }

            return validationResults;
        }

        private bool IsValidDate()
        {
            bool output = true;
            string[] dateFormats = {    "M/d/yyyy",
                                        "M/dd/yyyy",
                                        "MM/d/yyyy",
                                        "MM/dd/yyyy" };
            DateTime parsedDateTime;

            if (DateTime.TryParseExact(transactionDateTextBox.Text, dateFormats, new CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out parsedDateTime) == false)
            {
                output = false;
            }

            return output;
        }

        private bool IsValidAmount()
        {
            bool output = true;
            decimal transactionAmount;

            if (decimal.TryParse(transactionAmountTextBox.Text, out transactionAmount) == false)
            {
                output = false;
            }

            if (transactionAmount < 0)
            {
                output = false;
            }

            return output;
        }

        private bool IsValidDescription()
        {
            bool output = true;

            if (string.IsNullOrWhiteSpace(transactionDescriptionTextBox.Text))
            {
                output = false;
            }

            // If description is too long, don't save to database
            if (transactionDescriptionTextBox.Text.Length > 254)
            {
                output = false;
            }

            return output;
        }

        private bool IsValidCreditOrDebit()
        {
            bool output = false;

            if(creditOrDebitTextBox.Text == "1" || creditOrDebitTextBox.Text == "-1")
            {
                output = true;
            }

            return output;
        }
    }
}
