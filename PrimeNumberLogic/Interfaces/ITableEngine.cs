using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLogic.Interfaces
{
    public interface ITableEngine
    {
        //this would reside in a shared logic class so that we could have multiple engines. 
        //It could be turned into a service description/contract if we decided to change this into a serviced action.
    }
}
