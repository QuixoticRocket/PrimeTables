using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberLogic;
using Moq;
using PrimeNumberLogic.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class TableGeneratorTests
    {
        //we will need to mock the number generator
        //are there any edge cases we need to consider? what if N is 0? what if N is negative?
        //requirements state: N is a whole number and N is at least one. so we should use an unsigned int, and we should check for 0 (edge case)

        [TestMethod]
        public void N0_ThrowException()
        {
            Mock<INumberGenerator> numberGenerator = new Mock<INumberGenerator>(MockBehavior.Strict);
            TableGenerator generator = new TableGenerator(numberGenerator.Object);

            try
            {
                var answer = generator.GetMultiplicationTable(0);
                Assert.Fail("Should throw an exception if n = 0");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}
