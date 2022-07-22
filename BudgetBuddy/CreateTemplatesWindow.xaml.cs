using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for CreateEditTemplatesWindow.xaml
    /// </summary>
    public partial class CreateTemplatesWindow : Window
    {
        public CreateTemplatesWindow()
        {
            InitializeComponent();
        }

        private void saveNewTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Template Saved", "Template saved successfully!");
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
