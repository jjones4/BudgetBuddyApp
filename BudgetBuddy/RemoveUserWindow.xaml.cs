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
    /// Interaction logic for RemoveUserWindow.xaml
    /// </summary>
    public partial class RemoveUserWindow : Window
    {
        public RemoveUserWindow()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User successfully removed!", "User Removal");
            this.Close();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Operation successfully canceled", "User Removal");
            this.Close();
        }
    }
}
