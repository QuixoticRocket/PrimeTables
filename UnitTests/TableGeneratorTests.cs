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

        [TestMethod]
        public void N5_KnownTest()
        {
            Mock<INumberGenerator> numberGenerator = new Mock<INumberGenerator>(MockBehavior.Strict);
            TableGenerator generator = new TableGenerator(numberGenerator.Object);

            int[] numbers = new int[] { 2,3,4,5,7 };
            numberGenerator.Setup(x => x.GetNumbers(5)).Returns(numbers).Verifiable();

            var answer = generator.GetMultiplicationTable(5);

            Assert.AreEqual(6 * 6, answer.Length);
            Assert.IsNull(answer[0, 0]);
            Assert.AreEqual(2, answer[0, 1].Value);
            Assert.AreEqual(3, answer[0, 2].Value);
            Assert.AreEqual(4, answer[0, 3].Value);
            Assert.AreEqual(5, answer[0, 4].Value);
            Assert.AreEqual(7, answer[0, 5].Value);

            Assert.AreEqual(2, answer[1, 0].Value);
            Assert.AreEqual(4, answer[1, 1].Value);
            Assert.AreEqual(6, answer[1, 2].Value);
            Assert.AreEqual(8, answer[1, 3].Value);
            Assert.AreEqual(10, answer[1, 4].Value);
            Assert.AreEqual(14, answer[1, 5].Value);

            Assert.AreEqual(3, answer[2, 0].Value);
            Assert.AreEqual(6, answer[2, 1].Value);
            Assert.AreEqual(9, answer[2, 2].Value);
            Assert.AreEqual(12, answer[2, 3].Value);
            Assert.AreEqual(15, answer[2, 4].Value);
            Assert.AreEqual(21, answer[2, 5].Value);

            Assert.AreEqual(4, answer[3, 0].Value);
            Assert.AreEqual(8, answer[3, 1].Value);
            Assert.AreEqual(12, answer[3, 2].Value);
            Assert.AreEqual(16, answer[3, 3].Value);
            Assert.AreEqual(20, answer[3, 4].Value);
            Assert.AreEqual(28, answer[3, 5].Value);

            Assert.AreEqual(5, answer[4, 0].Value);
            Assert.AreEqual(10, answer[4, 1].Value);
            Assert.AreEqual(15, answer[4, 2].Value);
            Assert.AreEqual(20, answer[4, 3].Value);
            Assert.AreEqual(25, answer[4, 4].Value);
            Assert.AreEqual(35, answer[4, 5].Value);

            Assert.AreEqual(7, answer[5, 0].Value);
            Assert.AreEqual(14, answer[5, 1].Value);
            Assert.AreEqual(21, answer[5, 2].Value);
            Assert.AreEqual(28, answer[5, 3].Value);
            Assert.AreEqual(35, answer[5, 4].Value);
            Assert.AreEqual(49, answer[5, 5].Value);

            numberGenerator.VerifyAll();
        }
    }
}
