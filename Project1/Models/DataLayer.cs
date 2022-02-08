using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project1.Models
{
    public class DataLayer
    {
        DBManager db = new DBManager();

        public DataTable GetAllRecord(Property prop)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] p = new SqlParameter[]
                {
                    new SqlParameter("@action",prop.action),
                    new SqlParameter("@usr_id",prop.User_id),
                    new SqlParameter("@username",prop.Username),
                    new SqlParameter("@email",prop.Email),
                    new SqlParameter("@password",prop.Password),
                    new SqlParameter("@dob",prop.DOB),
                    new SqlParameter("@gender",prop.Gender),
                    new SqlParameter("@image",prop.picture),
                    new SqlParameter("@status",prop.Status),
                };
                dt = db.ExecuteDataTable("sp_form", p);
            }
            catch (Exception ex)
            {
                throw ;
            }
            return dt;
        }
    }
}