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
    /// Interaction logic for UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        public UserListWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editUser1_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUser = new EditUserWindow();
            editUser.Show();
        }

        private void editUser2_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUser = new EditUserWindow();
            editUser.Show();
        }

        private void editUser3_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUser = new EditUserWindow();
            editUser.Show();
        }

        private void removeUser2_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserWindow removeUser = new RemoveUserWindow();
            removeUser.Show();
        }

        private void removeUser1_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserWindow removeUser = new RemoveUserWindow();
            removeUser.Show();
        }

        private void removeUser3_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserWindow removeUser = new RemoveUserWindow();
            removeUser.Show();
        }
    }
}
