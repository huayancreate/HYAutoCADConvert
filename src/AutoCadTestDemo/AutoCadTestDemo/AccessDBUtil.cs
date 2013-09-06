using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace AutoCadConvert
{
    public class AccessDBUtil
    {
        private static String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Autocad.mdb";
        //private static String connectionString = AutoCadConvert.Properties.Settings.Default;
        private AccessDBUtil()
        {
        }
        //执行单条插入语句，并返回id，不需要返回id的用ExceuteNonQuery执行。
        public static int ExecuteInsert(string sql, OleDbParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"select @@identity";
                    int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                    return value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static int ExecuteInsert(string sql)
        {
            return ExecuteInsert(sql, null);
        }

        //执行带参数的sql语句,返回影响的记录数（insert,update,delete)
        public static int ExecuteNonQuery(string sql, OleDbParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        //执行不带参数的sql语句，返回影响的记录数
        //不建议使用拼出来SQL
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        //执行单条语句返回第一行第一列,可以用来返回count(*)
        public static int ExecuteScalar(string sql, OleDbParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                    return value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static int ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }

        //执行事务
        public static void ExecuteTrans(List<string> sqlList, List<OleDbParameter[]> paraList)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbTransaction transaction = null;
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    cmd.Transaction = transaction;

                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        cmd.CommandText = sqlList[i];
                        if (paraList != null && paraList[i] != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(paraList[i]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    throw e;
                }

            }
        }
        public static void ExecuteTrans(List<string> sqlList)
        {
            ExecuteTrans(sqlList, null);
        }

        //执行查询语句，返回dataset
        public static DataSet ExecuteQuery(string sql, OleDbParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
        }
        public static DataSet ExecuteQuery(string sql)
        {
            return ExecuteQuery(sql, null);
        }
        //执行查询语句返回datareader，使用后要注意close
        //这个函数在AccessPageUtils中使用，执行其它查询时最好不要用
        public static OleDbDataReader ExecuteReader(string sql)
        {
            //Debug.WriteLine(sql);
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }

    }
}
