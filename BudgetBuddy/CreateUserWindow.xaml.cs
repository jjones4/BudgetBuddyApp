using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        private List<string> selectedBudgets = new List<string>();

        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void createUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                SqlData data = new SqlData(config);

                // If the user did not type in any initial budgets
                if (selectedBudgets.Count < 1)
                {
                    data.CreateNewUser(userNameToAddTextBox.Text);

                    ((MainWindow)Application.Current.MainWindow).FillUsersComboBox();

                    MessageBox.Show("User Added Successfully!", "New User");
                }
                // If the user added some budgets, we need to perform
                // inserts in both the users AND the budgets tables
                else
                {
                    data.CreateNewUser(userNameToAddTextBox.Text);

                    data.CreateNewUserBudget(userNameToAddTextBox.Text, selectedBudgets);

                    ((MainWindow)Application.Current.MainWindow).FillUsersComboBox();
                    ((MainWindow)Application.Current.MainWindow).UpdateBudgetsList();

                    MessageBox.Show("User Added Successfully!", "New User");
                }

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBudgetToList_Click(object sender, RoutedEventArgs e)
        {
            if (budgetNameToAddTextBox.Text.Length > 0 && !String.IsNullOrWhiteSpace(budgetNameToAddTextBox.Text))
            {
                selectedBudgetsListBox.ItemsSource = null;
                selectedBudgets.Add(budgetNameToAddTextBox.Text);
                selectedBudgetsListBox.ItemsSource = selectedBudgets;
                budgetNameToAddTextBox.Clear();
            }
        }

        private void removeSelectedBudget_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBudgetsListBox.SelectedItem != null)
            {
                selectedBudgets.Remove(selectedBudgetsListBox.SelectedItem.ToString());
                selectedBudgetsListBox.ItemsSource = null;
                selectedBudgetsListBox.ItemsSource = selectedBudgets;
            }
        }

        private bool IsValidForm()
        {
            bool output = true;

            if (String.IsNullOrWhiteSpace(userNameToAddTextBox.Text))
            {
                MessageBox.Show("Please fill out a name for the new user.", "Form Error");
                output = false;
            }
            if (UserNameAlreadyExists())
            {
                MessageBox.Show("Username already in use. Please try another username.", "New User Error");
                output = false;
            }

            return output;
        }

        private bool UserNameAlreadyExists()
        {
            bool output = false;
            List<string> userNames = new List<string>();
            List<UserModel> users = new List<UserModel>();

            SqlData data = new SqlData(config);

            users = data.GetAllUsers().ToList();

            foreach (UserModel u in users)
            {
                if (u.UserName == userNameToAddTextBox.Text)
                {
                    output = true;
                }
            }

            return output;
        }
    }
}
