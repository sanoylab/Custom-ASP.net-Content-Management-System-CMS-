using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;


namespace Sanoy.AddisTower.DA
{
    public class SQLHelper
    {
        #region "Member Variable"
        public static string Message = "";
        public static string errorMsg = "";
        #endregion

        #region Static Methods
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            connection.Open();
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReader(SqlCommand Command)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Command.Connection = connection;
            connection.Open();
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            connection.Open();
            Command.Parameters.AddRange(parameters.ToArray());
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static object ExecuteScalar(string sql)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            object result = null;

            try
            {
                connection.Open();
                result = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static object ExecuteScalar(string sql, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            Command.Parameters.AddRange(parameters.ToArray());
            object result = null;

            try
            {
                connection.Open();
                result = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static object ExecuteScalar(SqlCommand Command)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Command.Connection = connection;
            object result = null;

            try
            {
                connection.Open();
                result = Command.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return result;
        }
        public static object ExecuteScalar(SqlCommand Command, CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            object result = null;
            Command.CommandType = commandType;

            try
            {
                connection.Open();
                result = Command.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            SqlCommand Command = new SqlCommand(sql);
            return ExecuteDataTable(Command);
        }
        public static DataTable ExecuteDataTable(SqlCommand Command)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Command.Connection = connection;
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);

            try
            {
                connection.Open();
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static DataTable ExecuteDataTable(string sql, List<SqlParameter> parameters)
        {
            SqlCommand Command = new SqlCommand(sql);
            Command.Parameters.AddRange(parameters.ToArray());
            return ExecuteDataTable(Command);
        }

        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            int result = -1;

            try
            {
                connection.Open();
                result = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static bool ExecuteNonQuery(SqlCommand Command)
        {
            int result = -1;
            Command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                Command.Connection.Open();
                result = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                Command.Connection.Close();
            }
            if (result != -1)
                return true;
            else
                return false;
        }
        public static int ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand Command = new SqlCommand(sql, connection);
            Command.Parameters.AddRange(parameters.ToArray());
            int result = -1;

            try
            {
                connection.Open();
                result = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Message = errorMsg.Replace("'", "");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static SqlDataReader ExecuteStoredProcedureReader(string SPName, ref ArrayList Parameters)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    cmd.Parameters.Add(Parameters[i]);
                }
            }
            connection.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static bool ExecuteTransaction(string[] sql)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            ArrayList CommandList = new ArrayList(0);
            connection.Open();
            SqlTransaction Transaction = connection.BeginTransaction(IsolationLevel.Serializable, "Transaction");

            for (int i = 0; i < sql.Length; i++)
            {
                SqlCommand TransactionCommand = new SqlCommand(sql[i], connection, Transaction);
                try
                {
                    TransactionCommand.ExecuteNonQuery();
                    CommandList.Add(TransactionCommand);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    errorMsg = ex.Message;
                    Message = errorMsg.Replace("'", "");
                }
            }
            Transaction.Commit();
            connection.Close();
            return true;
        }

        public static void ClearMessage()
        {
            Message = "";
            errorMsg = "";
        }


        #endregion
    }
}
