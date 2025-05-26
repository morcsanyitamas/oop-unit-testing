# Unit testing workshop

## Software testing
### Manual testing
* `Manual testing` is when a person checks the software by using it directly.
* You click on buttons, type in text, and look at the screen to see if everything works as expected.
* It's like checking if a recipe tastes good by trying a spoonful.
### Automated testing
* `Automated testing` uses computer programs to do the checking for us.
* We write special code that tells the computer what to test, and then the computer runs those tests automatically. This allows the computer to perform the same tests repeatedly, very quickly, ensuring that nothing has changed.
* It's like having a robot that can taste the recipe many times, very fast, and tell us if it's still good.

## Testing levels
* The [testing pyramid](https://www.google.com/search?q=testing+pyramid) is a way to visualize how we should structure our automated tests.
* At the bottom of the pyramid, we have `unit tests`, which form the foundation of our testing strategy. They are small, fast, and test individual pieces of our code, such as single functions or classes.
* As we move up the pyramid, we have `integration tests`, which check how different parts of our code work together.
* At the top, we have `end-to-end tests`, which verify the entire system’s functionality.

## Unit testing
* Unit testing is a way to check if small parts of a program (called "units") work correctly. A unit is usually a single function, method, or class.
* When we say that unit testing does not depend on integration points, it means that unit tests check only one small part of the code in isolation without relying on other components or external systems.

### Key characteristics of unit tests
* Isolated: It tests only one unit. A unit test focuses on a single function or class.
* No database, API, or external services: If the code normally connects to a database, a unit test should not use the real database.
* Fast and independent tests: Since unit tests do not depend on other parts of the system, they run quickly and give clear results.

## Test doubles
* When we write unit tests, we want to test only one small part of the code. However, sometimes the code depends on other parts, like databases, APIs, or external services. Running unit tests with real dependencies can be slow, unreliable, or difficult.
* To solve this problem, we use `test doubles`. A test double is a fake version of a real dependency. It helps us isolate the unit we are testing.

### Why Do We Use Test Doubles?
* Isolation – Unit tests should test only one function or class, without depending on other systems.
* Speed – Real databases and APIs are slow. Test doubles make tests run much faster.
* Reliability – External systems can fail or change. A test double always gives the expected result.
* Control – We can make test doubles return specific values to test different scenarios.
* Avoid Side Effects – Some code (like sending emails or writing to a database) should not run during testing. A test double prevents this.

### Types of Test Doubles
There are different types of test doubles, depending on what we need:
* Stub – A fake object that returns fixed values.
* Mock – A fake object that also checks if certain methods were called.
* Fake – A simplified version of a real system, used only for testing.

## Test-Driven Development (TDD)
* Test-Driven Development is a software development approach where tests are written before implementing functionality.
* Follows a Red-Green-Refactor cycle:
    * Red: Write a test that fails because the functionality doesn’t exist yet.
    * Green: Implement just enough code to make the test pass.
    * Refactor: Improve the code while ensuring all tests still pass.
* Benefits of TDD:
    * Ensures code correctness: helps catch errors early before they affect the final product.
    * Encourages better software design: guides developers to write modular and maintainable code.
    * Makes refactoring safer: ensures changes do not break existing functionality by keeping tests in place.

## Assignments
### Coffee Machine implementation
You are tasked with implementing the functionality of a coffee machine. The coffee machine should support the following features:
#### CoffeeMachine Logic
The Coffee Machine can make different types of coffee, such as *Espresso*, *Macchiato*, and *Cappuccino*. The coffee machine works as follows:
* Coffee Type: The machine makes three types of coffee:
    * Espresso (requires Arabica or Robusta beans)
    * Macchiato (requires Arabica or Robusta beans)
    * Cappuccino (requires Arabica or Robusta beans)
* Water Level: The coffee machine has a water level that starts at 100%. If the water level is too low (below 30%), it cannot make coffee.
* Cleaning: After 5 cups of coffee, the coffee machine needs cleaning.
* Coffee Service: The coffee machine depends on an external service to get the beans it needs to make coffee. This service will provide the either Arabica or Robusta beans based on the followings:
    * Provide Arabica beans if it is available.
    * Provide Robusta beans if Arabica beans are not available.
    * If both beans are not available, the service is not able to provide the beans.
    * Service has 80g of Arabica beans and 80g of Robusta beans and always provides 8g of beans for each coffee.
#### Operations
* MakeCoffee: The MakeCoffee function accepts a coffee type and checks if:
    * The water level is sufficient (greater than or equal to 30%).
    * The machine doesn't need cleaning.
    * The correct beans for the coffee type are available.
    * If all conditions are met, it prepares the coffee and decreases the water level by 10%.
* CleanMachine: The machine can be cleaned to reset the coffee count and allow more coffee to be made.
* RefillWater: The machine's water can be refilled back to 100%.
#### Hints
* Classes and Interfaces
    * ICoffeeService: Interface that provides coffee beans for different types of coffee.
    * CoffeeMachine: The class that implements the logic for making coffee, cleaning, and refilling water.

### Test doubles: Coffee Machine tests
1. Test that the coffee machine can successfully make an Espresso.
2. Test that the machine doesn't make coffee in case of invalid coffee type.
3. Test that the CoffeeMachine correctly interacts with ICoffeeService by calling GetCoffeeBeans exactly once per coffee request.
4. Test that the coffee machine can not make valid coffee if beans are not available.
5. Test that the coffee machine does not make coffee if the water level is too low (below 30%).
6. Test that the coffee machine can be refilled.

### Test Driven Development: Parking Lot System
You need to develop a simple Parking Lot System using Test-Driven Development (TDD) in C# with NUnit. The system should be able to track available parking spaces, add cars, and remove cars while ensuring that the lot does not exceed its capacity or go below zero.

#### Requirements
1. The Parking Lot should be initialized with a given capacity.
2. A method should allow checking the current number of available spaces.
3. Adding a car should decrease the number of available spaces.
4. Removing a car should increase the number of available spaces.
5. The system should prevent overfilling (i.e., no car should be added if the lot is full).
6. The system should prevent removing a car when the lot is empty.
