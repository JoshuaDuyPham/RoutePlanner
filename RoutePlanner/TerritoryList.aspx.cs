using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient; //this namespace is for sqlclient server  
using System.Configuration;

namespace RoutePlanner
{
    public partial class Territory : System.Web.UI.Page
    {
        
        public static SqlConnection dbConnection;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenSql();
        }

        public static void OpenSql()
        {

            try
            {
                string connectionString = @"Server = territory.c9t34bqnchfb.us-east-1.rds.amazonaws.com\SQLEXPRESS;Database = Territory; User ID = P0604133; Password = XL$w+9^9;";
                dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("error" + e.Message.ToString());
            }

        }
        /*
        public DataSet CreateTable(string name, string[] col, string[] colType)
        {
            if (col.Length != colType.Length)
            {
                throw new Exception("columns.Length != colType.Length");
            }
            string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];
            for (int i = 1; i < col.Length; ++i)
            {
                query += ", " + col[i] + " " + colType[i];
            }
            query += ")";
            return ExecuteQuery(query);
        }

        public DataSet CreateTableAutoID(string name, string[] col, string[] colType)
        {
            if (col.Length != colType.Length)
            {
                throw new Exception("columns.Length != colType.Length");
            }
            string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0] + " NOT NULL AUTO_INCREMENT";
            for (int i = 1; i < col.Length; ++i)
            {

                query += ", " + col[i] + " " + colType[i];
            }
            query += ", PRIMARY KEY (" + col[0] + ")" + ")";

            Debug.Log(query);

            return ExecuteQuery(query);
        }

        public DataSet InsertInto(string tableName, string[] values)
        {
            string query = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; ++i)
            {
                query += ", " + "'" + values[i] + "'";
            }
            query += ")";

            Debug.Log(query);
            return ExecuteQuery(query);
        }


        public DataSet InsertInto(string tableName, string[] col, string[] values)
        {

            if (col.Length != values.Length)
            {
                throw new Exception("columns.Length != colType.Length");
            }

            string query = "INSERT INTO " + tableName + " (" + col[0];
            for (int i = 1; i < col.Length; ++i)
            {
                query += ", " + col[i];
            }

            query += ") VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; ++i)
            {
                query += ", " + "'" + values[i] + "'";
            }
            query += ")";

            Debug.Log(query);
            return ExecuteQuery(query);
        }


        public DataSet SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)
        {
            if (col.Length != operation.Length || operation.Length != values.Length)
            {
                throw new Exception("col.Length != operation.Length != values.Length");
            }
            string query = "SELECT " + items[0];
            for (int i = 1; i < items.Length; ++i)
            {
                query += ", " + items[i];
            }
            query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + "'" + values[0] + "' ";
            for (int i = 1; i < col.Length; ++i)
            {
                query += " AND " + col[i] + operation[i] + "'" + values[0] + "' ";
            }
            return ExecuteQuery(query);
        }


        public DataSet UpdateInto(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue)
        {
            string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];
            for (int i = 1; i < colsvalues.Length; ++i)
            {
                query += ", " + cols[i] + " =" + colsvalues[i];
            }
            query += " WHERE " + selectkey + " = " + selectvalue + " ";
            return ExecuteQuery(query);
        }


        public DataSet Delete(string tableName, string[] cols, string[] colsvalues)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];
            for (int i = 1; i < colsvalues.Length; ++i)
            {
                query += " or " + cols[i] + " = " + colsvalues[i];
            }
            Debug.Log(query);
            return ExecuteQuery(query);
        }

        public void Close()
        {

            if (dbConnection != null)
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
            }

        }

        public static DataSet ExecuteQuery(string sqlString)
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                DataSet ds = new DataSet();
                try
                {

                    MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
                    da.Fill(ds);

                }
                catch (Exception ee)
                {
                    throw new Exception("SQL:" + sqlString + "/n" + ee.Message.ToString());
                }
                finally
                {
                }
                return ds;
            }
            return null;
        }
        */
    }
}