using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Browse from a published path only
 * Add reference: IPAddresses\bin\Release\IPAddresses.dll
 */
using IPAddresses;

namespace IPAddresses.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.test_ipv4();
            program.test_ipv6();
            //Console.ReadLine();
        }

        public void test_ipv4()
        {
            IPAddress ip_address = new IPAddress();

            string my_ipv4 = ip_address.my_ipv4();
            Console.WriteLine("My IPv4 is: "+ my_ipv4);
        }

        public void test_ipv6()
        {
            IPAddress ip_address = new IPAddress();

            string my_ipv6 = ip_address.my_ipv6();
            Console.WriteLine("My IPv6 is: " + my_ipv6);
        }
    }
}
