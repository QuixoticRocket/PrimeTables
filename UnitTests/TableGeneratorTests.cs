using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TableGeneratorTests
    {
        //we will need to mock the number generator
        //are there any edge cases we need to consider? what if N is 0? what if N is negative?
        //requirements state: N is a whole number and N is at least one. so we should use an unsigned int, and we should check for 0 (edge case)

        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            Assert.Fail();
        }
    }
}
