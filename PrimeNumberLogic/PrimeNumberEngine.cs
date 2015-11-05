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

        public PrimeNumberEngine()
        {

        }

        public int?[,] GenerateTable(uint n)
        {
            throw new NotImplementedException();
        }
    }
}
