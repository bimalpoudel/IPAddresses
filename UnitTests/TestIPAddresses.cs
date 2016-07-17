using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using IPAddresses.UnitTests.Helpers;

/**
 * @see https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.classinitializeattribute.aspx
 * @see http://stackoverflow.com/questions/6193744/what-would-be-an-alternate-to-setup-and-teardown-in-mstest
 * 
 * @see http://stackoverflow.com/questions/541954/how-would-you-count-occurrences-of-a-string-within-a-string
 */

namespace IPAddresses.UnitTests
{
    [TestClass]
    public class TestIPAddresses
    {
        /**
         * Sample micro-service reader
         */
        private string lorem_url = "http://bimal.org.np/micro-services/lorem/lorem.php";

        private void log(string message)
        {
            OutputLogger logger = new OutputLogger();
            logger.writeLog(message);
        }


        [TestMethod]
        public void BrowseURLTest()
        {
            URLFetcher uf = new URLFetcher();
            string lorem = "";
            lorem = uf.fetch(lorem_url);

            Assert.IsNotNull(lorem);

            this.log("Lorem Text was: " + lorem);
        }

        [TestMethod]
        public void FetchEmptyURLTest()
        {
            URLFetcher uf = new URLFetcher();

            string invalid_url = "";
            string invalid_data = uf.fetch(invalid_url);

            Assert.IsNotNull(invalid_data);
            Assert.AreEqual(invalid_data, "");
            Console.WriteLine("Invalid data: "+ invalid_data);

            this.log("Invalid URL attempted to Open: " + invalid_data);
        }

        [TestMethod]
        public void FindMyIPv6AddressTest()
        {
            IPAddress ipaddress = new IPAddress();
            string my_ipv6 = ipaddress.my_ipv6();

            //Assert.IsNotNull(my_ipv6);

            // check for 7 colons and alphanumeric
            //int count_colons = my_ipv6.count(colons => colons == ':');
            int count_colons = my_ipv6.Split(':').Length - 1;
            Assert.AreEqual(count_colons, 7);

            this.log("Found My IPv6 Address: " + my_ipv6);
        }

        [TestMethod]
        public void FindMyIPv4AddressTest()
        {
            IPAddress ipaddress = new IPAddress();
            string my_ipv4 = ipaddress.my_ipv4();

            //Assert.IsNotNull(my_ipv4);

            // check for 3 dots and numeric
            //int count_dots = my_ipv4.count(dots => dots == '.');
            int count_dots = my_ipv4.Split('.').Length - 1;
            Assert.AreEqual(count_dots, 3);

            this.log("Found My IPv4 Address: " + my_ipv4);
        }        
    }
}