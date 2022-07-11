using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Models
{
    /// <summary>
    /// Represents one of a user's templates
    /// </summary>
    public class TemplateModel
    {
        /// <summary>
        /// Represents the id of one of the user's templates
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of one of the user's templates
        /// </summary>
        public string NameOfTemplate { get; set; } = "";

        /// <summary>
        /// Represents all the line items comprising one of the user's templates
        /// </summary>
        public List<TransactionModel> Template { get; set; } = new List<TransactionModel>();
    }
}
