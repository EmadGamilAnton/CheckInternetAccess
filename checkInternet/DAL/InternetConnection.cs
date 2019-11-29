using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace checkInternet.DAL
{
    public class InternetConnection
    {
        public string checkInternetConnection()
        {
            //check internet connection by pin google.com website 
            //if reply is success that means there is internet access 
            try
            {
                Ping myPing = new Ping();
                String host = "8.8.8.8";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer);

                string status = reply.Status.ToString();

                Console.WriteLine("ststus " + status);
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ex.Message;
            }
        }
       /* public bool checkInternetConnection2()
        {
            try
            {
                var client = new WebClient();
                client.OpenRead("http://google.com/");
                return true;
            }
            catch
            {
                return false;
            }
        }*/
    }
}
