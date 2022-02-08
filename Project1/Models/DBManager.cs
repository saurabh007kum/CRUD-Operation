using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project1.Models
{
    public class DBManager
    {
        public SqlConnection conn;

        public DBManager()
        {
            string constr = ConfigurationManager.ConnectionStrings["MyConn"].ToString();
            conn = new SqlConnection(constr);
        }
        public DataTable ExecuteDataTable(string Pro_Name, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try 
            { 
                SqlCommand command = new SqlCommand(Pro_Name, conn);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int IUD(string Pro_Name,SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(Pro_Name, conn);
            command.CommandType = CommandType.StoredProcedure;
            foreach(SqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int n = command.ExecuteNonQuery();
            conn.Close();
            return n; 
        }
    }
}