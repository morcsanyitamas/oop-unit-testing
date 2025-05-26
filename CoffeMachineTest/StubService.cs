using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;

namespace CoffeMachineTest
{
    class StubService : ICoffeeService
    {
        public string GetCoffeeBeans(CoffeeType type)
        {
            if (type == CoffeeType.Espresso)
                return "Here is your Espresso coffee!";
            return "";
        }
    }
}
