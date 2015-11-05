using PrimeNumberLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLogic
{
    internal class PrimeNumberGenerator : INumberGenerator
    {
        private List<int> foundPrimes = new List<int>();

        //generates prime numbers
        public int[] GetNumbers(uint numberToGet)
        {
            int[] answers = new int[numberToGet];

            int i = 0;
            while(foundPrimes.Count < numberToGet)
            {
                int foundprime = 0;
                if(i == 0)
                {
                    foundprime = 2;
                }
                else
                {
                    //more complicated code for finding primes here (we can't just map case statement to a list of prime ;)
                    throw new NotImplementedException();
                }

                foundPrimes.Add(foundprime);
                i++;
            }

            answers = foundPrimes.ToArray();
            return answers;
        }
    }
}
