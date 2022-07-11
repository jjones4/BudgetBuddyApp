using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Models
{
    /// <summary>
    /// Represents one of the user's who uses the app
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Represents the id of one of the user's who uses the app
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the username of one of the user's who uses the app
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// Represents all budgets the user has created
        /// </summary>
        public List<BudgetModel> Budget { get; set; } = new List<BudgetModel>();

        /// <summary>
        /// Represents all templates the user has created
        /// </summary>
        public List<TemplateModel> Templates { get; set; } = new List<TemplateModel>();
    }
}
