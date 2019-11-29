using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace checkInternet
{
    public partial class LoginForm : Form
    {
        DC.User userO = new DC.User();
        DAL.InternetConnection connO = new DAL.InternetConnection();

      
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            string conn = connO.checkInternetConnection();
            if (conn == "Success")
            {
                DataTable dt = new DataTable();
                dt = userO.userLogin(usernameTXT.Text, passwordTXT.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login success");
                }
                else
                {
                    MessageBox.Show("login faield");
                }

            }
            else
            {
                MessageBox.Show("Check Your Internet Connection");
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
