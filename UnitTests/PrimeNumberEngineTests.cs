using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PrimeNumberEngineTests
    {
        //this should simply use some mocks to ensure that there are no hiccups in the code path
        //this class should remain quite clean and simple.

        //we will need to use PrivateObject to switch out classes create in the constructor with our mocks.

        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            Assert.Fail();
        }
    }
}
