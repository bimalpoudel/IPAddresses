using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAddresses.UnitTests.Helpers
{
    internal class OutputLogger
    {
        /**
         * @see IPAddresses\UnitTests\bin\Debug\*.log
         */
        private string writeTo = "ip-address.log";

        /**
         * @see http://www.dotnetperls.com/datetime-format
         */
        private string datetime_format = "u";

        public void writeLog(string message)
        {
            DateTime localDateTime = DateTime.Now;
            string timestamp = localDateTime.ToString(datetime_format);

            System.IO.StreamWriter file = new System.IO.StreamWriter(this.writeTo, true);
            file.WriteLine(timestamp + ": " + message);
            file.Close();
        }

    }
}
