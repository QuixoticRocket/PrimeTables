using PrimeNumberLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLogic
{
    public class PrimeNumberEngine : ITableEngine
    {
        //we're allowing these to be accessed internally so that we can use setter injection for testing.
        //if we were using construction injection then this wouldn't be necessary
        internal INumberGenerator numberGenerator
        {
            private get; set;
        }
        internal TableGenerator tableGenerator
        {
            private get; set;
        }

        /// <summary>
        /// An engine for producing a multiplication table consisting of products of primes
        /// </summary>
        public PrimeNumberEngine()
        {
            numberGenerator = new PrimeNumberGenerator();
            tableGenerator = new TableGenerator(numberGenerator);
        }

        /// <summary>
        /// Generates the table
        /// </summary>
        /// <param name="n">the number of prime numbers to use when generating the table (should be greater than 0)</param>
        /// <returns>a 2d array of nullable integers. only 0,0 should be null.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if n is 0</exception>
        public int?[,] GenerateTable(uint n)
        {
            return tableGenerator.GetMultiplicationTable(n);
        }
    }
}
