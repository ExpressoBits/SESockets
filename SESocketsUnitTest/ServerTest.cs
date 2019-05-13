using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SESockets.TCP;
using System.Net;

namespace SESocketsUnitTest
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void SameIP()
        {
            Server server = new Server(27455);
            Assert.AreEqual(server.ip.ToString(),IPAddress.Any.ToString());
            Console.WriteLine(server.ip.ToString());
        }
    }
}
