using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimeNumberLogic.Interfaces;
using PrimeNumberLogic;

namespace UnitTests
{
    [TestClass]
    public class PrimeNumberEngineTests
    {
        //this should simply use some mocks to ensure that there are no hiccups in the code path
        //this class should remain quite clean and simple.

        //we will need to use PrivateObject to switch out classes create in the constructor with our mocks. (or use internal setter injection for testing)

        [TestMethod]
        public void CreateSimpleTable()
        {
            Mock<INumberGenerator> numberGenerator = new Mock<INumberGenerator>(MockBehavior.Strict);
            Mock<TableGenerator> tableGenerator = new Mock<TableGenerator>(MockBehavior.Strict);

            IPrimeNumberEngine engine = new IPrimeNumberEngine();

            engine.numberGenerator = numberGenerator.Object;
            engine.tableGenerator = tableGenerator.Object;

            int?[,] table = new int?[3, 3] { { null, 1, 2 }, { 1, 1, 2 }, { 2, 2, 4 } };

            tableGenerator.Setup(x => x.GetMultiplicationTable(2)).Returns(table);

            var answer = engine.GenerateTable(2);

            Assert.AreEqual(table, answer);
        }
    }
}
