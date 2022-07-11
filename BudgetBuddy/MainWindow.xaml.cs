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
            else
            {
                MessageBox.Show("Please make a selection for all fields.", "Form Error");
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
            UserListWindow userList = new UserListWindow();
            userList.Show();
        }

        private void removeUserLink_Click(object sender, RoutedEventArgs e)
        {
            UserListWindow userList = new UserListWindow();
            userList.Show();
        }

        private void FillUsersComboBox()
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
            budgets = data.GetAllUserBudgetNames(selectedUserNameComboBox.SelectedItem.ToString())
                          .OrderBy(x => x.NameOfBudget).ToList();

            foreach (BudgetModel b in budgets)
            {
                budgetNames.Add(b.NameOfBudget);
            }

            selectedBudgetComboBox.ItemsSource = budgetNames;
        }

        private bool IsValidForm()
        {
            bool output = true;

            // I could put both checks into an "OR" conditional
            // I kept them separate in case I want to give specific
            // error messages for each one
            if (selectedUserNameComboBox.Text.Length < 1)
            {
                output = false;
            }

            if (selectedBudgetComboBox.Text.Length < 1)
            {
                output = false;
            }

            return output;
        }
    }
}
