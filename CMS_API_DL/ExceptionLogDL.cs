using System;
using System.Data;
using System.Data.SqlClient;

namespace CMS_API_DL
{
    public class ExceptionLogDL
    {
        public static void SendExcepToDB(Exception exdb, long userID, string excepURLFunction, string connectionstring = null)
        {

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //excepURLFunction = "";
                    //conn.ConnectionString = "Server =.; Database = Zapures; Trusted_Connection = true;";
                    //cmd.Connection =null;
                    //cmd.CommandText = "[dbo].[USP_ERROR_API_ExceptionLog_Insert]";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@UserID", userID);
                    //cmd.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
                    //cmd.Parameters.AddWithValue("@ExceptionURL", excepURLFunction);
                    //cmd.Parameters.AddWithValue("@ExceptionSource", exdb.GetType().Name.ToString() + " " + exdb.StackTrace.ToString());
                    //if (cmd.Connection.State != ConnectionState.Open)
                    //{
                    //    cmd.Connection.Open();
                    //}
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(ds);
                }
            }
        }
    }
}
