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

        [TestMethod]
        public void N1_SmallTable()
        {
            Mock<INumberGenerator> numberGenerator = new Mock<INumberGenerator>(MockBehavior.Strict);
            TableGenerator generator = new TableGenerator(numberGenerator.Object);

            int[] numbers = new int[] { 3 };
            numberGenerator.Setup(x => x.GetNumbers(1)).Returns(numbers).Verifiable();

            var answer = generator.GetMultiplicationTable(1);

            Assert.AreEqual(2 * 2, answer.Length);
            Assert.IsNull(answer[0, 0]);
            Assert.AreEqual(3, answer[0, 1].Value);
            Assert.AreEqual(3, answer[1, 0].Value);
            Assert.AreEqual(3*3, answer[1, 1].Value);

            numberGenerator.VerifyAll();
        }
    }
}
