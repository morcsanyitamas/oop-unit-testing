using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;

namespace CoffeMachineTest
{
    class FakeService : ICoffeeService
    {
        public string GetCoffeeBeans(CoffeeType type)
        {
            switch (type)
            {
                case CoffeeType.Espresso:
                case CoffeeType.Macchiato:
                case CoffeeType.Cappuccino:
                    return "Arabica";
                default:
                    return "None";
            }
        }
    }
}
