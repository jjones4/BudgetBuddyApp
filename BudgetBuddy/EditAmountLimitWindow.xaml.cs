using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for EditAmountLimitWindow.xaml
    /// </summary>
    public partial class EditAmountLimitWindow : Window
    {
        public EditAmountLimitWindow()
        {
            InitializeComponent();
        }

        private void saveNewTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Limt Saved", "New limit saved successfully!");
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
