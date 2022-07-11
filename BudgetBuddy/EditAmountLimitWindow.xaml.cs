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
