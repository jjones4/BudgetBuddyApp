using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        public MainWindow()
        {
            InitializeComponent();

            FillUsersComboBox();
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                BudgetHomeWindow home = new BudgetHomeWindow();
                home.Show();
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void addUserLink_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUser = new CreateUserWindow();
            createUser.Show();
        }

        private void editUserLink_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidUserName())
            {
                EditUserWindow editUser = new EditUserWindow();
                editUser.Show();
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Username Error");
            }
        }

        private void removeUserLink_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidUserName())
            {
                RemoveUserWindow removeUser = new RemoveUserWindow();
                removeUser.Show();
            }
            else
            {
                MessageBox.Show("Please select a user to remove.", "User Selection Error");
            }
        }

        public void FillUsersComboBox()
        {
            List<UserModel> users = new List<UserModel>();
            List<string> userNames = new List<string>();

            SqlData data = new SqlData(config);
            users = data.GetAllUsers().OrderBy(x => x.UserName).ToList();

            foreach (UserModel u in users)
            {
                userNames.Add(u.UserName);
            }

            selectedUserNameComboBox.ItemsSource = userNames;
        }

        private void selectedUserNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<BudgetModel> budgets = new List<BudgetModel>();
            List<string> budgetNames = new List<string>();

            SqlData data = new SqlData(config);

            if (selectedUserNameComboBox.SelectedItem != null)
            {
                budgets = data.GetAllUserBudgets(selectedUserNameComboBox.SelectedItem.ToString())
                          .OrderBy(x => x.NameOfBudget).ToList();

                foreach (BudgetModel b in budgets)
                {
                    budgetNames.Add(b.NameOfBudget);
                }

                selectedBudgetComboBox.ItemsSource = budgetNames;
            }
        }

        public void UpdateBudgetsList()
        {
            List<BudgetModel> budgets = new List<BudgetModel>();
            List<string> budgetNames = new List<string>();

            SqlData data = new SqlData(config);

            if (selectedUserNameComboBox.SelectedItem != null)
            {
                budgets = data.GetAllUserBudgets(selectedUserNameComboBox.SelectedItem.ToString())
                          .OrderBy(x => x.NameOfBudget).ToList();

                foreach (BudgetModel b in budgets)
                {
                    budgetNames.Add(b.NameOfBudget);
                }

                selectedBudgetComboBox.ItemsSource = budgetNames;
            }
            else
            {
                selectedBudgetComboBox.ItemsSource = null;
            }
        }

        private bool IsValidForm()
        {
            bool output = true;

            if (selectedUserNameComboBox.Text.Length < 1 && selectedBudgetComboBox.Text.Length < 1)
            {
                MessageBox.Show("Please make a selection for all fields.", "Form Error");
                output = false;
            }

            if (selectedUserNameComboBox.Text.Length > 1 && selectedBudgetComboBox.Text.Length < 1)
            {
                List<BudgetModel> budgets = new List<BudgetModel>();
                SqlData data = new SqlData(config);

                budgets = data.GetAllUserBudgets(selectedUserNameComboBox.SelectedItem.ToString())
                          .OrderBy(x => x.NameOfBudget).ToList();

                if (budgets.Count > 0)
                {
                    MessageBox.Show("Please select a budget for this user.", "Form Error");
                }
                else
                {
                    MessageBox.Show("No budgets were found for this user. Please add a budget by selecting \"Edit User.\"", "Form Error");
                }

                output = false;
            }

            return output;
        }

        private bool IsValidUserName()
        {
            bool output = true;

            if (selectedUserNameComboBox.Text.Length < 1)
            {
                output = false;
            }

            return output;
        }
    }
}
