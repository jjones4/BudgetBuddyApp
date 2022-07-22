using BudgetLibrary.DataLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows;

namespace BudgetBuddy
{
    /// <summary>
    /// Interaction logic for RemoveUserWindow.xaml
    /// </summary>
    public partial class RemoveUserWindow : Window
    {
        private IConfiguration config = App.serviceProvider.GetService<IConfiguration>();

        public RemoveUserWindow()
        {
            InitializeComponent();

            userNameTextBlock.Text =
                ((MainWindow)Application.Current.MainWindow).selectedUserNameComboBox.Text;
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            // get all the budgets by username sp
            // for each of the above budgets, remove budget sp

            string oldUserName = userNameTextBlock.Text;
            List<BudgetModel> budgets = new List<BudgetModel>();
            List<TemplateModel> templates = new List<TemplateModel>();

            SqlData data = new SqlData(config);

            budgets = data.GetAllUserBudgets(userNameTextBlock.Text);

            foreach(BudgetModel budget in budgets)
            {
                string budgetName = budget.NameOfBudget;

                data.DeleteBudget(userNameTextBlock.Text, budgetName);
            }

            templates = data.GetAllUserTemplates(userNameTextBlock.Text);

            foreach (TemplateModel template in templates)
            {
                string templateName = template.NameOfTemplate;

                data.DeleteTemplate(userNameTextBlock.Text, templateName);
            }

            data.DeleteUser(oldUserName);

            ((MainWindow)Application.Current.MainWindow).FillUsersComboBox();
            ((MainWindow)Application.Current.MainWindow).UpdateBudgetsList();

            MessageBox.Show("User and all associated data successfully removed!", "User Removal");
            this.Close();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Operation successfully canceled", "User Removal");
            this.Close();
        }
    }
}
