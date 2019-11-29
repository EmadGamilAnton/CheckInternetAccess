using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkInternet.DAL
{
    class DAL
    {
        SqlConnection sqlconnection = new SqlConnection(); // object of sql connection

        public DAL()
        {
            // This for Server configuration Connection string 
            sqlconnection = new SqlConnection(@"Data Source=.\,1433;Initial Catalog=your database name;User ID=user id;Password=password");
        }
        
        //open connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        //close connection 
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        //method to read data from DB
        public DataTable SelectData(String stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand(); //sql command 
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //excution command
        public void ExcutionCommand(String stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand(); //command object
            sqlcmd.CommandType = CommandType.StoredProcedure; //command type
            sqlcmd.CommandText = stored_procedure; //command text take stored procedure
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
