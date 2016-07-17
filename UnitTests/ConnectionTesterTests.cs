using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAddresses.UnitTests
{
    [TestClass()]
    public class ConnectionTesterTests
    {
        [TestMethod()]
        public void is_connectedTest()
        {
            ConnectionTester ct = new ConnectionTester();
            Boolean is_connected = ct.is_connected();

            Assert.IsTrue(is_connected);
        }
    }
}