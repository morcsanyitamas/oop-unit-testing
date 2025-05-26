using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private readonly ICoffeeService _coffeeService;
        private int _coffeeCount = 0;
        private bool _needsCleaning = false;
        private int _waterLevel = 100; // Water in %

        public CoffeeMachine(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        public string MakeCoffee(CoffeeType type)
        {
            if (_needsCleaning)
                return "Cleaning needed before making more coffee.";

            if (_waterLevel < 30)
                return "Not enough water to make coffee.";

            string beans = _coffeeService.GetCoffeeBeans(type);
            if (beans == "None")
                return "No beans available for this type.";

            _coffeeCount++;
            _waterLevel -= 10;

            if (_coffeeCount >= 5)
                _needsCleaning = true;

            return $"Here is your {type} coffee!";
        }

        public void CleanMachine()
        {
            _needsCleaning = false;
            _coffeeCount = 0;
        }

        public void RefillWater()
        {
            _waterLevel = 100;
        }
    }
}
