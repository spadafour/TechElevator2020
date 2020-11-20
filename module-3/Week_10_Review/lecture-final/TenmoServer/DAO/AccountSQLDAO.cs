using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSQLDAO : IAccountDAO
    {
        private string connectionString { get; }
        public AccountSQLDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Account GetAccountByAccountId(int accountId)
        {
            Account returnAccount = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT account_id, balance, user_id FROM accounts WHERE account_Id = @accountId ", conn);
                    cmd.Parameters.AddWithValue("@accountId", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnAccount = GetAccountFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnAccount;

        }

        public List<Account> GetAccountsByUserId(int userId)
        {
            List<Account> output = new List<Account>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT account_id, balance, user_id FROM accounts WHERE user_id = @userid", conn);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(GetAccountFromReader(reader));
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }

        public List<AccountWithUser> GetAccountWithUsers()
        {
            List<AccountWithUser> output = new List<AccountWithUser>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT account_id, balance, u.user_id,u.userName FROM accounts as a join users as u on u.user_id = a.user_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                         Account temp = GetAccountFromReader(reader);
                        output.Add(new AccountWithUser(temp, Convert.ToString(reader["userName"])));
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;

        }

        private Account GetAccountFromReader(SqlDataReader reader)
        {
            Account account = new Account()
            {
                AccountId = Convert.ToInt32(reader["account_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Balance = Convert.ToDecimal(reader["balance"])
            };

            return account;
        }

    }
}
