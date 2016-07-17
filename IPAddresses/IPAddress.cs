using System;
namespace IPAddresses
{

    public class IPAddress
    {
        // 000.000.000.000
        private string ipv4_lookup_url { get; set; }

        // 0000:0000:0000:0000:0000:0000:0000:0000
        private string ipv6_lookup_url { get; set; }

        public IPAddress()
        {
            /**
             * Chooses which lookup service to use
             */
           this.initialize_whatismyipaddress();
        }

        /**
         * Define the best selected IP Address determining tool
         * @see http://whatismyipaddress.com/api
         */
        private void initialize_whatismyipaddress()
        {

            /**
             * IPv4 or IPv6 lookup URL
             */
            //this.lookup_url = "http://bot.whatismyipaddress.com/";

            /**
             * IPv4 only lookup URL
             */
            this.ipv4_lookup_url = "http://ipv4bot.whatismyipaddress.com/";

            /**
             * IPv6 only lookup URL
             */
            this.ipv6_lookup_url = "http://ipv6bot.whatismyipaddress.com/";

        }


        /**
         * Pickup one of the IP Address lookup service
         */
        private string ip_lookup_url(string ipvx = "")
        {
            string ip_lookup_url = null;
            switch(ipvx)
            {
                case "ipv4":
                    ip_lookup_url = this.ipv4_lookup_url;
                    break;
                case "ipv6":
                    ip_lookup_url = this.ipv6_lookup_url;
                    break;
                default:
                    throw new Exception("IP Version Number was not chosen in the lookup request.");
            }
            return ip_lookup_url;
        }

        /**
         * Interface to IP Lookup on demand
         */
        private string my_ip(string ipvx="")
        {
            string ip_lookup_url = this.ip_lookup_url(ipvx);
            if (null == ip_lookup_url)
            {
                throw new Exception("IP Lookup URLs were not initilaized. Hints: call initilize_xxx().");
            }

            URLFetcher uf = new URLFetcher();
            string ip_address = uf.fetch(ip_lookup_url);

            return ip_address;
        }

        /**
         * Public API to lookup IPv4
         */
        public string my_ipv4()
        {
            return this.my_ip("ipv4");
        }

        /**
         * Public API to lookup IPv6
         */
        public string my_ipv6()
        {
            return this.my_ip("ipv6");
        }

        /**
         * Has this computer got Network and Internet connection?
         */
        public bool is_connected()
        {
            ConnectionTester ct = new ConnectionTester();
            Boolean is_connected = ct.is_connected();

            return is_connected;
        } 
    }
}