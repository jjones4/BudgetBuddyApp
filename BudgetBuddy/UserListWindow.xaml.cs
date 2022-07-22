using System.Windows;

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
