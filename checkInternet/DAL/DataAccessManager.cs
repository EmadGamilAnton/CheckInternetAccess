using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace DefaultDesign.DataAccessManager
{
    class DataAccessManager
    {
        SqlConnection sqlconnection = new SqlConnection(); // object of sql connection

        public DataAccessManager()
        {
            // This for Server configuration string 
//sqlconnection = new SqlConnection(@"Data Source=.\,1433;Initial Catalog=san_stefanodb;User ID=e;Password=rootem");
           // Amazon
           sqlconnection = new SqlConnection(@"Data Source=xamarin.cbmw1gn7xmp8.me-south-1.rds.amazonaws.com,1433;Database= san_stefano;User ID=;Password=");
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
            sqlcmd.CommandType  = CommandType.StoredProcedure;
            sqlcmd.CommandText  = stored_procedure;
            sqlcmd.Connection   = sqlconnection;
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
            sqlcmd.CommandType  = CommandType.StoredProcedure; //command type
            sqlcmd.CommandText  = stored_procedure; //command text take stored procedure
            sqlcmd.Connection   = sqlconnection; 
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
