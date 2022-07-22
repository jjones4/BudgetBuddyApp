using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.DataAccessLayer
{
    public class SqlDataAccess
    {
        private IConfiguration _config;

        private readonly string connectionStringName = ConnectionConfiguration.GetConnectionStringName();

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public void RunStoredProcedure_Create(StoredProcedureModel storedProcedure)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure.NameOfStoredProcedure, connection))
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(storedProcedure.ParameterList.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Object[] RunStoredProcedure_Read(StoredProcedureModel storedProcedure)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            Object[] output;
            int numRows;
            int numFields;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure.NameOfStoredProcedure, connection))
                    {
                        connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(storedProcedure.ParameterList.ToArray());
                        SqlDataReader dr = cmd.ExecuteReader();

                        numRows = 0;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                numRows++;
                            }
                        }

                        dr.Close();

                        dr = cmd.ExecuteReader();
                        numFields = dr.FieldCount;

                        output = new object[numRows * numFields];

                        if (dr.HasRows)
                        {
                            int counter = 0;
                            Object[] fields = new object[dr.FieldCount];

                            while (dr.Read())
                            {
                                dr.GetValues(fields);

                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    output[counter] = fields[i];
                                    counter++;
                                }
                            }
                        }

                        dr.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return output;
        }

        public void RunStoredProcedure_Update(StoredProcedureModel storedProcedure)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure.NameOfStoredProcedure, connection))
                    {
                        connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(storedProcedure.ParameterList.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RunStoredProcedure_Delete(StoredProcedureModel storedProcedure)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure.NameOfStoredProcedure, connection))
                    {
                        connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(storedProcedure.ParameterList.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
