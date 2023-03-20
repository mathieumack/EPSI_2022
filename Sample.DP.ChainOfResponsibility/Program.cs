using Sample.DP.ChainOfResponsibility.Domain;
    
Console.WriteLine("Hello World! We will make some pizza!");

// Build handlers :
var pizzaHandler = new PizzaHandler();
var pizzaCheeseHandler = new PizzaCheeseHandler();
var pizzaTomatoHandler = new PizzaTomatoHandler();
var PizzaMushroomHandler = new PizzaMushroomHandler();

// Manage the chain of responsibility :
pizzaHandler.nextHandler(pizzaTomatoHandler);
pizzaTomatoHandler.nextHandler(PizzaMushroomHandler);
PizzaMushroomHandler.nextHandler(pizzaCheeseHandler);

var pizza = new Pizza();
pizzaHandler.Handle(pizza);

Console.WriteLine($"Pizza is ready with ingredients: {string.Join(", ", pizza.Ingredients)}");
