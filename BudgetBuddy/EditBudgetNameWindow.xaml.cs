using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

                MessageBox.Show("Budget Name Updated Successfully!", "Budget Updated");

                // Remove the selected (old) budget from the selectedBudgets List
                // Set the list to null
                // rebuild the list from the database
                // update the budgets combo box on the edit user window
                // update the budgets combo box on the main window

                // _editUserWindow.userBudgetsComboBox.Text = newUserNameTextBox.Text;

                // ((MainWindow)Application.Current.MainWindow).FillUsersComboBox();

                // this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValidForm()
        {
            bool output = true;

            if (newBudgetNameTextBox.Text.Length < 1)
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

            budgets = data.GetAllUserBudgetNames(_editUserWindow.userNameTextBlock.Text).ToList();

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
