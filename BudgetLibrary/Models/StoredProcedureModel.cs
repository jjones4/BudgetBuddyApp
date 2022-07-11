using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Models
{
    public class StoredProcedureModel
    {
        public string NameOfStoredProcedure { get; set; } = "";

        public List<SqlParameter> ParameterList { get; set; } = new List<SqlParameter>();
    }
}
