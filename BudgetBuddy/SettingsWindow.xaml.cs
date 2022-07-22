using System.Windows;

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
