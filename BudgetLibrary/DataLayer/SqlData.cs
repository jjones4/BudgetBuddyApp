using BudgetLibrary.DataAccessLayer;
using BudgetLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.DataLayer
{
    public class SqlData
    {
        private IConfiguration _config;

        public SqlData(IConfiguration config)
        {
            _config = config;
        }

        public void CreateNewUser(string userToCreate)
        {
            SqlDataAccess db = new SqlDataAccess(_config);

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spUsers_AddNewUser",
                ParameterList = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = userToCreate }
                }
            };

            db.RunStoredProcedure_Create(storedProcedure);
        }

        public void UpdateUserName(string newUserName, string oldUserName)
        {
            SqlDataAccess db = new SqlDataAccess(_config);

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spUsers_UpdateUserName",
                ParameterList = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = newUserName },
                    new SqlParameter("@OldUserName", SqlDbType.NVarChar) { Value = oldUserName}
                }
            };

            db.RunStoredProcedure_Update(storedProcedure);
        }

        public void UpdateBudgetName(string newBudgetName, string oldBudgetName, string userName)
        {
            SqlDataAccess db = new SqlDataAccess(_config);

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spBudgets_UpdateBudgetName",
                ParameterList = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = userName },
                    new SqlParameter("@BudgetName", SqlDbType.NVarChar) { Value = newBudgetName },
                    new SqlParameter("@OldBudgetName", SqlDbType.NVarChar) { Value = oldBudgetName}
                }
            };

            db.RunStoredProcedure_Update(storedProcedure);
        }

        public void CreateNewUserBudget(string userName, List<string> selectedBudgets)
        {
            SqlDataAccess db = new SqlDataAccess(_config);

            foreach (var budget in selectedBudgets)
            {
                StoredProcedureModel storedProcedure = new StoredProcedureModel
                {
                    NameOfStoredProcedure = "spBudgets_AddNewUserBudget",
                    ParameterList = new List<SqlParameter>
                    {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = userName },
                    new SqlParameter("@BudgetName", SqlDbType.NVarChar) { Value = budget }
                    }
                };

                db.RunStoredProcedure_Create(storedProcedure);
            }
        }

        public List<UserModel> GetAllUsers()
        {
            SqlDataAccess db = new SqlDataAccess(_config);
            List<UserModel> users = new List<UserModel>();
            Object[] objects;

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spUsers_GetAllUsers"
            };

            objects = db.RunStoredProcedure_Read(storedProcedure);

            int counter = 0;
            foreach (var item in objects)
            {
                if (counter >= objects.Count())
                {
                    break;
                }

                users.Add(new UserModel { Id = (int)objects[counter], UserName = (string)objects[counter + 1] });
                
                counter += 2;
            }

            return users;
        }

        public List<BudgetModel> GetAllUserBudgetNames(string selectedUser)
        {
            SqlDataAccess db = new SqlDataAccess(_config);
            List<BudgetModel> userBudgets = new List<BudgetModel>();
            Object[] objects;

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spBudgets_GetBudgetsByUserName",
                ParameterList = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = selectedUser }
                }
            };

            objects = db.RunStoredProcedure_Read(storedProcedure);

            int counter = 0;
            foreach (var item in objects)
            {
                if (counter >= objects.Count())
                {
                    break;
                }

                userBudgets.Add(new BudgetModel { Id = (int)objects[counter], NameOfBudget = (string)objects[counter + 1] });

                counter += 2;
            }

            return userBudgets;
        }

        public List<TransactionModel> GetAllUserBudgetLineItems(string selectedUser, string selectedBudgetName)
        {
            SqlDataAccess db = new SqlDataAccess(_config);
            List<TransactionModel> userBudget = new List<TransactionModel>();
            Object[] objects;

            StoredProcedureModel storedProcedure = new StoredProcedureModel
            {
                NameOfStoredProcedure = "spLineItems_GetLineItemsByUserBudget",
                ParameterList = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = selectedUser },
                    new SqlParameter("@BudgetName", SqlDbType.NVarChar) { Value = selectedBudgetName }
                }
            };

            objects = db.RunStoredProcedure_Read(storedProcedure);

            int counter = 0;
            foreach (var item in objects)
            {
                if (counter >= objects.Count())
                {
                    break;
                }

                userBudget.Add(new TransactionModel
                {
                    Id = (int)objects[counter],
                    DateOfTransaction = (DateTime)objects[counter + 1],
                    AmountOfTransaction = (decimal)objects[counter + 2],
                    DescriptionOfTransaction = (string)objects[counter + 3],
                    CreditOrDebit = (int)objects[counter + 4],
                    IsLarge = (bool)objects[counter + 5],
                    BudgetId = (int)objects[counter + 6]
                });

                counter += 7;
            }

            return userBudget;
        }
    }
}
