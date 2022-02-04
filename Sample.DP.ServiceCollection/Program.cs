// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Sample.DP.ServiceCollection.Abstractions;
using Sample.DP.ServiceCollection.Domain;
using Sample.DP.ServiceCollection.Domain.Ingredients.Cheeses;
using Sample.DP.ServiceCollection.Domain.Ingredients.Sauces;
using Sample.DP.ServiceCollection.Domain.Pizzas;
using Sample.DP.ServiceCollection.Domain.Stores;
using Sample.DP.ServiceCollection.Services;

#region Service collection initialization

// Configuring servicecollection to register all class :
IServiceCollection serviceCollection = new ServiceCollection();

// Register all ingredients as transient as each request of an ingredient must create a new instance:
serviceCollection.AddTransient<EmmenthalCheese>();
serviceCollection.AddTransient<MozzarellaCheese>();
serviceCollection.AddTransient<RoquefortCheese>();

serviceCollection.AddTransient<FreshCreamSauce>();
serviceCollection.AddTransient<TomatoSauce>();

// Also for types of Pizza as each pizza is unique
serviceCollection.AddTransient<KidPizza>();
serviceCollection.AddTransient<CheesePizza>();

// Register all ingredient service as singleton. We register the interface
serviceCollection.AddSingleton<ICheesesServices, CheesesServices>();
serviceCollection.AddSingleton<IPizzaIngredientService, PizzaIngredientService>();
serviceCollection.AddSingleton<ISaucesServices, SaucesServices>();

// Register all stores as singleton also
serviceCollection.AddSingleton<AlpesStore>();
serviceCollection.AddSingleton<ParisStore>();

var provider = serviceCollection.BuildServiceProvider();

#endregion

// Start the application :
Console.WriteLine("Hello, Please select your store : Paris or Alpes");
var storeName = Console.ReadLine();

PizzaStore store;
if(storeName == "Paris")
{
    store = provider.GetService<ParisStore>();
}
else
{
    store = provider.GetService<AlpesStore>();
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