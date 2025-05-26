using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;
using Moq;

namespace CoffeMachineTest
{
    class CoffeeMachineTest
    {

        // Test that the coffee machine can successfully make an Espresso.
        [Test]
        public void CoffeeMacine_MakeExpresso_Successfully()
        {
            var service = new StubService();
            var machinie = new CoffeeMachine.CoffeeMachine(service);

            var coffee = machinie.MakeCoffee(CoffeeType.Espresso);

            Assert.That(coffee, Is.EqualTo("Here is your Espresso coffee!"));
        }

        // Test that the machine doesn't make coffee in case of invalid coffee type.
        [Test]
        public void CoffeeMacine_InvalidCoffeeType_NoBeans()
        {
            var service = new FakeService();
            var machinie = new CoffeeMachine.CoffeeMachine(service);

            var coffee = machinie.MakeCoffee((CoffeeType)5);

            Assert.That(coffee, Is.EqualTo("No beans available for this type."));
        }

        [Test]
        public void CoffeeMachine_CallGetCoffeeBeansOnce()
        {
            var service = new Mock<ICoffeeService>();
            service.Setup(service => service.GetCoffeeBeans(CoffeeType.Espresso)).Returns("Arabica");
            var machinie = new CoffeeMachine.CoffeeMachine(service.Object);
            
            var coffee = machinie.MakeCoffee(CoffeeType.Espresso);
            service.Verify(service => service.GetCoffeeBeans(CoffeeType.Espresso), Times.Once);

            Assert.That(coffee, Is.EqualTo("Here is your Espresso coffee!"));
        }
    }
}
