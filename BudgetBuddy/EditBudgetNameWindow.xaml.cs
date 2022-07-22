using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for EditBudgetNameWindow.xaml
    /// </summary>
    public partial class EditBudgetNameWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        private EditUserWindow _editUserWindow;

        public EditBudgetNameWindow(EditUserWindow editUserWindow)
        {
            InitializeComponent();

            _editUserWindow = editUserWindow;

            oldBudgetNameTextBlock.Text = _editUserWindow.userBudgetsComboBox.Text;
        }

        private void saveBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                string oldBudgetName = _editUserWindow.userBudgetsComboBox.Text;

                SqlData data = new SqlData(config);

                data.UpdateBudgetName(newBudgetNameTextBox.Text, oldBudgetName, _editUserWindow.userNameTextBlock.Text);

                ((MainWindow)Application.Current.MainWindow).UpdateBudgetsList();

                _editUserWindow.PopulateUserInfo();

                MessageBox.Show("Budget Name Updated Successfully!", "Budget Updated");

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValidForm()
        {
            bool output = true;

            if (String.IsNullOrWhiteSpace(newBudgetNameTextBox.Text))
            {
                MessageBox.Show("Please fill out the new budget name.", "Form Error");
                output = false;
            }
            if (BudgetNameAlreadyExists())
            {
                MessageBox.Show("Budget name already in use. Please try another budget name.", "New Budget Error");
                output = false;
            }

            return output;
        }

        private bool BudgetNameAlreadyExists()
        {
            bool output = false;
            List<string> budgetNames = new List<string>();
            List<BudgetModel> budgets = new List<BudgetModel>();

            SqlData data = new SqlData(config);

            budgets = data.GetAllUserBudgets(_editUserWindow.userNameTextBlock.Text).ToList();

            foreach (BudgetModel budget in budgets)
            {
                if (budget.NameOfBudget == newBudgetNameTextBox.Text)
                {
                    output = true;
                }
            }

            return output;
        }
    }
}
