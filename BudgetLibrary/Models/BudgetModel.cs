using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Models
{
    /// <summary>
    /// Represents one of a user's budgets
    /// </summary>
    public class BudgetModel
    {
        /// <summary>
        /// The id of one budget of a user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of one of the user's budgets
        /// </summary>
        public string NameOfBudget { get; set; } = "";

        /// <summary>
        /// Represents all the transactions comprising one of the user's budgets
        /// </summary>
        public List<TransactionModel> Budget { get; set; } = new List<TransactionModel>();
    }
}
