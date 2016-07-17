using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace IPAddresses
{
    public class ConnectionTester
    {
        /**
         * @see http://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
         */
        public Boolean is_connected()
        {
            Boolean is_connected = false;
            
            is_connected = this.openGoogleHomePage();
            //is_connected = this.pingGoogleServer();
            //is_connected = this.checkIPHostEntry();

            return is_connected;
        }

        /**
         * @todo Find out the time taken to process.
         */
        private Boolean openGoogleHomePage()
        {
            Boolean is_connected = false;

            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com/"))
                    {
                        is_connected = true;
                    }
                }
            }
            catch
            {
                // return false;
            }

            return is_connected;
        }

        /**
         * @todo Find out the time taken to process.
         */
        private Boolean pingGoogleServer()
        {
            Boolean is_connected = false;

            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;

                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

                is_connected = (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                //return false;
            }

            return is_connected;
        }

        /**
         * @todo Find out the time taken to process.
         */
        public bool checkIPHostEntry()
        {
            Boolean is_connected = false;

            try
            {
                System.Net.IPHostEntry ihe = System.Net.Dns.GetHostEntry("www.google.com");
                is_connected = true;
            }
            catch
            {
                //return false;
            }

            return is_connected;
        }
    }
}
