using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Models
{
    /// <summary>
    /// Represents one line item (transaction) in a budget
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Represents the id of one line item (transaction) in a budget
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the date the transaction took place
        /// </summary>
        public DateTime DateOfTransaction { get; set; } = new DateTime();

        /// <summary>
        /// Represents the amount of money the transaction was worth
        /// </summary>
        public decimal AmountOfTransaction { get; set; }

        /// <summary>
        /// Represents the user's description of their transaction
        /// </summary>
        public string DescriptionOfTransaction { get; set; } = "";

        /// <summary>
        /// Represents whether to multiply the amount of the transaction
        /// by (1) for a credit or by (-1) for a debit
        /// </summary>
        public int CreditOrDebit { get; set; }

        /// <summary>
        /// Represenets if a user defines this transaction amount as being
        /// too larget to go in their "regular" budget
        /// </summary>
        public bool IsLarge { get; set; }

        /// <summary>
        /// Represents the Id from the Budgets table
        /// </summary>
        public int BudgetId { get; set; }
    }
}
