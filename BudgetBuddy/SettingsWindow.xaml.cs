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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void removeUsersLink_Click(object sender, RoutedEventArgs e)
        {
            UserListWindow userList = new UserListWindow();
            userList.Show();
        }

        private void regularExpenseLimitLink_Click(object sender, RoutedEventArgs e)
        {
            EditAmountLimitWindow amountLimit = new EditAmountLimitWindow();
            amountLimit.Show();
        }

        private void addTransactionTemplateLink_Click(object sender, RoutedEventArgs e)
        {
            CreateTemplatesWindow createTemplate = new CreateTemplatesWindow();
            createTemplate.Show();
        }

        private void editTransactionTemplatesLink_Click(object sender, RoutedEventArgs e)
        {
            EditTemplatesWindow editTemplate = new EditTemplatesWindow();
            editTemplate.Show();
        }

        private void removeTransactionTemplatesLink_Click(object sender, RoutedEventArgs e)
        {
            RemoveTemplateWindow removeTemplate = new RemoveTemplateWindow();
            removeTemplate.Show();
        }
    }
}
