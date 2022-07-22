using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for RemoveTemplateWindow.xaml
    /// </summary>
    public partial class RemoveTemplateWindow : Window
    {
        public RemoveTemplateWindow()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Template removed successfully!", "Template Removal");
            this.Close();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
