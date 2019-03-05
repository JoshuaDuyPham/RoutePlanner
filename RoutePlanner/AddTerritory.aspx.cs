using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoutePlanner
{
    public partial class AddTerritory : System.Web.UI.Page
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
        protected void Submit_Click(object sender, EventArgs e)
        {
            var parameters = Request.Form["SubType"];

            try
            {
                string insert = "INSERT INTO Territory (Id, CheckedOut, Owner, FullName, ShortName) values(@Id, @CheckedOut, @Owner, @FullName, @ShortName)";
                SqlCommand cmd = new SqlCommand(insert, dbConnection);
                cmd.Parameters.AddWithValue("@Id", TerritoryID.Text);
                cmd.Parameters.AddWithValue("@CheckedOut", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Owner", "Joshua Pham");
                cmd.Parameters.AddWithValue("@FullName", FNameInput.Text);
                cmd.Parameters.AddWithValue("@ShortName", SNameInput.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("TerritoryList.aspx", false);
                dbConnection.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}