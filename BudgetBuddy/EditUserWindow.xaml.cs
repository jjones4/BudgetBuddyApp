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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();
        private List<string> selectedBudgets = new List<string>();

        public EditUserWindow()
        {
            InitializeComponent();

            PopulateUserInfo();
        }

        private void editUserNameLink_Click(object sender, RoutedEventArgs e)
        {
            EditUserNameWindow editUserName = new EditUserNameWindow(this);
            editUserName.Show();
        }

        private void editBudgetNameLink_Click(object sender, RoutedEventArgs e)
        {
            EditBudgetNameWindow editBudgetName = new EditBudgetNameWindow(this);
            editBudgetName.Show();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveUserButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User Updated Successfully!", "User Updated");

            this.Close();
        }

        public void PopulateUserInfo()
        {
            userNameTextBlock.Text =
                ((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text;

            userBudgetsComboBox.ItemsSource = ((MainWindow)Application.Current.MainWindow).selectedBudgetComboBox.Items;
        }

        private void addBudgetToListButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidBudgetName())
            {
                budgetsToAddListBox.ItemsSource = null;
                selectedBudgets.Add(addBudgetToListTextBox.Text);
                budgetsToAddListBox.ItemsSource = selectedBudgets;
                addBudgetToListTextBox.Clear();
            }
        }

        private void removeSelectedBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            if (budgetsToAddListBox.SelectedItem != null)
            {
                selectedBudgets.Remove(budgetsToAddListBox.SelectedItem.ToString());
                budgetsToAddListBox.ItemsSource = null;
                budgetsToAddListBox.ItemsSource = selectedBudgets;
            }
        }

        private bool IsValidBudgetName()
        {
            bool output = true;

            if (String.IsNullOrWhiteSpace(addBudgetToListTextBox.Text))
            {
                MessageBox.Show("Please fill out a budget name.", "Form Error");
                output = false;
            }

            foreach (string budgetName in selectedBudgets)
            {
                if (addBudgetToListTextBox.Text == budgetName)
                {
                    output = false;

                    MessageBox.Show("The budget name you entered is already in the list.", "Budget Name Error");
                }
            }

            SqlData data = new SqlData(config);
            List<BudgetModel> budgets = data.GetAllUserBudgets(userNameTextBlock.Text);

            foreach (var budget in budgets)
            {
                if (addBudgetToListTextBox.Text == budget.NameOfBudget)
                {
                    output = false;

                    MessageBox.Show("The budget name you entered already exists in the database.", "Budget Name Error");
                }
            }

            return output;
        }

        private void removeBudgetLink_Click(object sender, RoutedEventArgs e)
        {
            if (userBudgetsComboBox.SelectedItem != null)
            {
                string oldBudgetName = userBudgetsComboBox.Text;

                SqlData data = new SqlData(config);

                data.DeleteBudget(userNameTextBlock.Text, userBudgetsComboBox.SelectedItem.ToString());

                ((MainWindow)Application.Current.MainWindow).UpdateBudgetsList();

                PopulateUserInfo();

                MessageBox.Show($"Budget { oldBudgetName } successfully removed!", "Budget Removal");
            }
        }

        private void saveNewBudgets_Click(object sender, RoutedEventArgs e)
        {
            SqlData data = new SqlData(config);

            data.CreateNewUserBudget(userNameTextBlock.Text, selectedBudgets);

            ((MainWindow)Application.Current.MainWindow).UpdateBudgetsList();

            PopulateUserInfo();

            MessageBox.Show($"Budgets added successfully!", "Budget Addition");
        }
    }
}
