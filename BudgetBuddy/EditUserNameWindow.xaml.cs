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
    /// Interaction logic for EditUserNameWindow.xaml
    /// </summary>
    public partial class EditUserNameWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        private EditUserWindow _editUserWindow;

        public EditUserNameWindow(EditUserWindow editUserWindow)
        {
            InitializeComponent();

            _editUserWindow = editUserWindow;

            oldUserNameTextBlock.Text = _editUserWindow.userNameTextBlock.Text;
        }

        private void saveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                string oldUserName = _editUserWindow.userNameTextBlock.Text;

                SqlData data = new SqlData(config);

                data.UpdateUserName(newUserNameTextBox.Text, oldUserName);

                MessageBox.Show("User Updated Successfully!", "User Updated");

                _editUserWindow.userNameTextBlock.Text = newUserNameTextBox.Text;

                ((MainWindow)Application.Current.MainWindow).FillUsersComboBox();

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

            if (String.IsNullOrWhiteSpace(newUserNameTextBox.Text))
            {
                MessageBox.Show("Please fill out the new username.", "Form Error");
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
                if (u.UserName == newUserNameTextBox.Text)
                {
                    output = true;
                }
            }

            return output;
        }
    }
}
