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
                if(i == 0) //we could make this slightly faster by prepopulating the first few primes. we know 2 is the first followed by 3. but that defeats the point 
                {
                    foundprime = 2;
                }
                else
                {
                    int candidate = foundPrimes[foundPrimes.Count - 1] +1; //get the next candidate
                    while(foundprime == 0)
                    {
                        foreach (int prime in foundPrimes)
                        {
                            if(candidate % prime == 0) //if the candidate is divisible by a previous candidate then it is not a prime. stop checking and continue
                            {
                                candidate++;
                                continue;
                            }
                        }
                        foundprime = candidate; //finally found the next prime.
                    }
                }

                foundPrimes.Add(foundprime); //record and continue (or exit if we've gotten enough primes)
                i++;
            }

            answers = foundPrimes.ToArray();
            return answers;
        }
    }
}
