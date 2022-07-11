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
