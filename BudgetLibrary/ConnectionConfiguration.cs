using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary
{
    // Allows the name of the connection string to be set from App.xaml.cs
    // Allows SqlData to have access to the connection string from the library
    public static class ConnectionConfiguration
    {
        private static string _connectionStringName = "";

        public static void SetConnectionStringName(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        public static string GetConnectionStringName()
        {
            return _connectionStringName;
        }

    }
}
