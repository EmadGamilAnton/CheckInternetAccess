using System;
using System.Data;
using System.Data.SqlClient;

namespace checkInternet.DC
{
    class User
    {
        DAL.DAL DALO = new DAL.DAL();
        DataTable DTO = new DataTable();

        public DataTable userLogin(string username, string password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@userName", SqlDbType.VarChar, 100);
            param[0].Value = username;

            param[1] = new SqlParameter("@userPassword", SqlDbType.VarChar, 100);
            param[1].Value = password;

            DALO.Open();
            DTO = DALO.SelectData("userLogin", param);
            return DTO;           
        }
       
    }
}
