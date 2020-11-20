using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSQLDAO : ITransferDAO
    {
        private const int Send = 2;
        private const int Approved = 2;

        private readonly string connectionString;
        public TransferSQLDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Transfer AddTransfer(Transfer transfer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlStatement = "Insert into transfers(transfer_type_id, transfer_status_id, account_from, account_to, amount)" +
                        " VALUES (@transferType, @transferStatus, @accountFrom, @accountTo, @amount);select scope_identity();";
                    SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                    cmd.Parameters.AddWithValue("@transferType", Send);
                    cmd.Parameters.AddWithValue("@transferStatus", Approved);
                    cmd.Parameters.AddWithValue("@accountFrom", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@accountTo", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                    transfer.TransferId = Convert.ToInt32(cmd.ExecuteScalar());
                    // don't forget to transfer the money
                    TransferMoney(transfer.Amount, transfer.AccountFrom, transfer.AccountTo);
                }
                return transfer;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<TransferDetail> GetTransferDetails(int userId)
        {
            List<TransferDetail> output = new List<TransferDetail>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlStatement = "select t.transfer_id,account_to,account_from,amount,uf.username as FromUser,ut.username as ToUser,transfer_status_desc,transfer_type_desc from transfers as t " +
                        "join accounts as af on t.account_from = af.account_id " +
                        "join users as uf on uf.user_id = af.user_id " +
                        "join accounts as at on t.account_to = at.account_id " +
                        "join users as ut on ut.user_id = at.user_id " +
                        "join transfer_types as tt on tt.transfer_type_id = t.transfer_type_id " +
                        "join transfer_statuses as ts on ts.transfer_status_id = t.transfer_status_id "+
                        "where uf.user_id = @user_Id or ut.user_id = @user_Id";
                    SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                    cmd.Parameters.AddWithValue("@user_Id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        output.Add(TransferDetailFromReader(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }

        private bool TransferMoney(decimal amount, int acctFrom, int acctTo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE accounts SET balance = (balance - @amount) WHERE account_id = @accountFrom; UPDATE accounts SET balance = (balance + @amount) WHERE account_id = @accountTo", conn);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@accountFrom", acctFrom);
                    cmd.Parameters.AddWithValue("@accountTo", acctTo);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private TransferDetail TransferDetailFromReader(SqlDataReader reader)
        {
            TransferDetail output = new TransferDetail()
            {
                TransferId = Convert.ToInt32(reader["transfer_id"]),
                AccountTo = Convert.ToInt32(reader["account_to"]),
                AccountFrom = Convert.ToInt32(reader["account_from"]),
                Amount = Convert.ToDecimal(reader["amount"]),
                From = Convert.ToString(reader["FromUser"]),
                To = Convert.ToString(reader["ToUser"]),
                Status = Convert.ToString(reader["transfer_status_desc"]),
                Type = Convert.ToString(reader["transfer_type_desc"])
            };
            return output;
        }
    }
}



