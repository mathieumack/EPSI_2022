// See https://aka.ms/new-console-template for more information
using Sample.DP.Factory.Domain;
using Sample.DP.Factory.Domain.Stores;

Console.WriteLine("Hello, Please select your store : Paris or Alpes");
var storeName = Console.ReadLine();

PizzaStore store;
if(storeName == "Paris")
{
    store = new ParisStore();
}
else
{
    store = new AlpesStore();
}

// Now we can ask for a pizza :
var availablePizzas = store.GetAvailablePizzas();
Console.WriteLine("Available pizzas :");
foreach(var availablePizzaName in availablePizzas)
    Console.WriteLine($"    - {availablePizzaName}");
Console.WriteLine("Select the pizza that you want :");
var pizzaName = Console.ReadLine();

// Now we can prepare the pizza:
var pizza = store.Order(pizzaName);
Console.WriteLine($"Your pizza {pizza.Name} is prepared. Ingredients :");
Console.WriteLine($"    Sauce : {pizza.Sauce.Name}.");
foreach (var pizzaCheese in pizza.Cheeses)
    Console.WriteLine($"    Cheese : {pizzaCheese.Name}");