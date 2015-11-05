using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberLogic;

namespace UnitTests
{
    [TestClass]
    public class PrimeNumberGeneratorTests
    {
        //things to think about:
        //what are our boundries? is there such a thing as a negative prime? 
        //edge cases? we cannot generate a negative amount of numbers. generating 0 number will result in an empty return.

        //PRIME NUMBER DEFINITION:
        //A prime number (or a prime) is a natural number greater than 1 that has no positive divisors other than 1 and itself.

        [TestMethod]
        public void Test_n0_returnsEmpty()
        {
            //generate zero numbers means empty list

            PrimeNumberGenerator generator = new PrimeNumberGenerator();
            var answer = generator.GetNumbers(0);
            Assert.AreEqual(0, answer.Length);
        }

        [TestMethod]
        public void Test_n1_returns_2()
        {
            //first prime is 2

            PrimeNumberGenerator generator = new PrimeNumberGenerator();
            var answer = generator.GetNumbers(1);
            Assert.AreEqual(2, answer[0]);
        }

        [TestMethod]
        public void Test_n5_returns_correct()
        {
            //first primes are 2, 3, 5, 7, 11

            PrimeNumberGenerator generator = new PrimeNumberGenerator();
            var answer = generator.GetNumbers(5);
            Assert.AreEqual(5, answer.Length);
            Assert.AreEqual(2, answer[0]);
            Assert.AreEqual(3, answer[1]);
            Assert.AreEqual(5, answer[2]);
            Assert.AreEqual(7, answer[3]);
            Assert.AreEqual(11, answer[4]);
        }
    }
}
