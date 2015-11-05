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
                    int candidate = foundPrimes[foundPrimes.Count - 1] +1;
                    while(foundprime == 0)
                    {
                        foreach (int prime in foundPrimes)
                        {
                            if(candidate % prime == 0)
                            {
                                candidate++;
                                continue;
                            }
                        }
                        foundprime = candidate;
                    }
                }

                foundPrimes.Add(foundprime);
                i++;
            }

            answers = foundPrimes.ToArray();
            return answers;
        }
    }
}
