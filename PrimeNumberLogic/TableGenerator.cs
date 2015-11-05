using PrimeNumberLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLogic
{
    internal class TableGenerator
    {
        //takes an INumberGenerator (constructor injection) and produces a 2d array of multiplications
        //this class could be interfaced so that we could switch out the types of tables we generate, but it's overkill for this project

        //requirements state: N is a whole number and N is at least one. so we should use an unsigned int, and we should check for 0 (edge case)

        private INumberGenerator numberGenerator;

        public TableGenerator(INumberGenerator numberGenerator)
        {
            this.numberGenerator = numberGenerator;
        }

        public int?[,] GetMultiplicationTable(uint n)
        {
            if(n == 0)
            {
                throw new ArgumentOutOfRangeException("n must be 1 or greater");
            }

            uint nPlusOne = n + 1;

            int[] numbers = numberGenerator.GetNumbers(n);
            int?[,] answer = new int?[nPlusOne, nPlusOne];

            answer[0, 0] = null;

            //set the known numbers on the first row and column
            for (int i = 1; i < nPlusOne; i++)
            {
                int currentnumber = numbers[i - 1];
                answer[i, 0] = answer[0, i] = currentnumber;
            }

            int centerlinePosition = 1;
            while(centerlinePosition < nPlusOne)
            {
                answer[centerlinePosition, centerlinePosition] = answer[0, centerlinePosition] * answer[centerlinePosition, 0];
                for (int i = centerlinePosition + 1; i < nPlusOne; i++)
                {
                    int product = answer[centerlinePosition, 0].Value * answer[i, 0].Value;
                    answer[centerlinePosition, i] = answer[i, centerlinePosition] = product;
                }

                centerlinePosition++;
            }

            return answer;
        }
    }
}
