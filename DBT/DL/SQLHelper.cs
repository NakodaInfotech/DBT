using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SQLHelper
    {
        #region"Declare Variables"

        //private static SqlConnection m_conn = null;
        //public static SqlTransaction m_transaction;

        #endregion

        #region "Attach Parameters"

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter param in commandParameters)
            {
                try
                {
                    if (param.Value == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    else if (param.Value.ToString() == "1/1/1999 12:00:00 AM")
                    {
                        param.Value = DBNull.Value;
                    }
                    else if (param.Value.ToString() == DateTime.MinValue.ToString())
                    {
                        param.Value = DBNull.Value;
                    }
                    else if (param.Value.ToString() == "01/01/1999 00:00:00")
                    {
                        param.Value = DBNull.Value;
                    }
                    command.Parameters.Add(param);
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }

        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            try
            {
                if ((commandParameters == null) || (parameterValues == null))
                {
                    return;
                }
                for (int i = 0, j = commandParameters.Length; i < j; i++)
                {
                    try
                    {
                        commandParameters[i].Value = parameterValues[i];
                    }
                    catch { }

                }
            }
            catch
            {
            }
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.Transaction = transaction;
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        #endregion

        #region "Execute Non Query"
        public static int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string spName, params object[] parameterValues)
        {

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {

                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, transaction, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connection, transaction, CommandType.StoredProcedure, spName, commandParameters);
            }

            else
            {
                return ExecuteNonQuery(connection, transaction, CommandType.StoredProcedure, spName);
            }
        }
        public static int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
                int returnVal = cmdExecute.ExecuteNonQuery();
                return returnVal;
            }
        }
        public static int ExecuteNonQueryTimeConsume(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                cmdExecute.CommandTimeout = 6000;
                PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
                int returnVal = cmdExecute.ExecuteNonQuery();
                return returnVal;
            }
        }

        #endregion

        #region "Connection String"

        public static SqlConnection OpenConnection(string connstr)
        {

            SqlConnection m_conn = new SqlConnection(connstr);

            if ((m_conn.State == ConnectionState.Broken) || (m_conn.State == ConnectionState.Closed))
            {
                m_conn.Open();
            }
            return m_conn;
        }

        public static SqlConnection OpenConnection()
        {
            //string connstr = ConfigurationSettings.AppSettings["connString"].ToString();
            string connstr = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            SqlConnection m_conn = new SqlConnection(connstr);

            if ((m_conn.State == ConnectionState.Broken) || (m_conn.State == ConnectionState.Closed))
            {
                m_conn.Open();
            }


            return m_conn;

        }

        public static void CloseConnection(Object obj)
        {
            SqlConnection m_conn = (SqlConnection)obj;
            if (m_conn.State == ConnectionState.Open)
            {
                m_conn.Close();
                m_conn.Dispose();
            }
        }
        #endregion

        #region "Transaction"
        public static void StartTransaction()
        {
            //m_transaction = m_conn.BeginTransaction();

        }

        public static void CommitTransaction()
        {
            //m_transaction.Commit();

        }

        public static void RollBackTransaction()
        {
            //m_transaction.Rollback();
        }
        #endregion

        #region "Execute Dataset"
        public static DataSet ExecuteDataset(SqlConnection cn, SqlTransaction t, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(cn, t, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(cn, t, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteDataset(cn, t, CommandType.StoredProcedure, spName);
            }
        }
        public static DataSet ExecuteDataset(SqlConnection connection, SqlTransaction t, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                PrepareCommand(cmdExecute, connection, t, commandType, commandText, commandParameters);
                using (SqlDataAdapter daExecute = new SqlDataAdapter(cmdExecute))
                {
                    using (DataSet dstExecute = new DataSet())
                    {
                        cmdExecute.CommandTimeout = 100000;
                        daExecute.Fill(dstExecute);
                        cmdExecute.Parameters.Clear();
                        return dstExecute;
                    }
                }
            }
        }
        #endregion

        #region "Execute Scalar"
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, transaction, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connection, transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteScalar(connection, transaction, CommandType.StoredProcedure, spName);
            }
        }
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
                object returnVal = cmdExecute.ExecuteScalar();
                cmdExecute.Parameters.Clear();
                return returnVal;
            }

        }
        #endregion

        #region "Class SqlHelper"
        public sealed class SqlHelperParameterCache
        {
            private SqlHelperParameterCache() { }
            private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

            private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
            {

                SqlCommand cmdExecute = new SqlCommand();
                cmdExecute.CommandType = CommandType.StoredProcedure;
                cmdExecute.CommandText = spName;
                cmdExecute.Connection = connection;
                // AlternativeDeriveParameters adParams = new AlternativeDeriveParameters();
                //cmdExecute.Transaction=transaction;
                SqlCommandBuilder.DeriveParameters(cmdExecute);

                if (!includeReturnValueParameter)
                {
                    cmdExecute.Parameters.RemoveAt(0);
                }
                SqlParameter[] discoveredParameters = new SqlParameter[cmdExecute.Parameters.Count];
                cmdExecute.Parameters.CopyTo(discoveredParameters, 0);
                return discoveredParameters;
            }
            private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
            {

                SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
                for (int i = 0, j = originalParameters.Length; i < j; i++)
                {
                    clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
                }

                return clonedParameters;
            }

            public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
            {
                string hashKey = ConfigurationSettings.AppSettings["ConnectionString"].ToString() + ":" + commandText;
                paramCache[hashKey] = commandParameters;
            }

            public static SqlParameter[] GetCachedParameterSet(SqlConnection connection, string commandText)
            {
                string hashKey = ConfigurationSettings.AppSettings["ConnectionString"].ToString() + ":" + commandText;
                SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
                if (cachedParameters == null)
                {
                    return null;
                }
                else
                {
                    return CloneParameters(cachedParameters);
                }
            }
            public static SqlParameter[] GetSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName)
            {
                return GetSpParameterSet(connection, transaction, spName, false);
            }
            public static SqlParameter[] GetSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
            {
                //string connectionString = "";
                string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
                SqlParameter[] cachedParameters;
                cachedParameters = (SqlParameter[])paramCache[hashKey];
                if (cachedParameters == null)
                {
                    cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connection, transaction, spName, includeReturnValueParameter));
                }
                return CloneParameters(cachedParameters);
            }
        }
        #endregion
    }
}
