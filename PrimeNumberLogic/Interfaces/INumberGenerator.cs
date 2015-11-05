using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLogic.Interfaces
{
    internal interface INumberGenerator
    {
        //needs a method that takes an int N and returns N numbers (int array)
        //internal interface. seems silly, but this doesn't get consumed outside the class and so it stays internal. 
        //this would become public if we had external generators that we could swap around, and then it would reside in a shared space (shared logic project)
        int[] GetNumbers(uint numberToGet);
    }
}
