using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for EditTemplatesWindow.xaml
    /// </summary>
    public partial class EditTemplatesWindow : Window
    {
        public EditTemplatesWindow()
        {
            InitializeComponent();
        }

        private void saveTemplateButton_Click(object sender, RoutedEventArgs e)
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
