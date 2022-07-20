﻿using BudgetLibrary.DataLayer;
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

        private void PopulateUserInfo()
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

            if (addBudgetToListTextBox.Text.Length < 1)
            {
                output = false;

                MessageBox.Show("Please type a name for your budget.", "Budget Name Error");
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
            List<BudgetModel> budgets = data.GetAllUserBudgetNames(userNameTextBlock.Text);

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
    }
}
