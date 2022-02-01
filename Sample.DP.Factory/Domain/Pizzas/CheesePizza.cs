namespace Sample.DP.Factory.Domain.Pizzas
{
    internal class CheesePizza : Pizza
    {
        public override string Name => "Cheese pizza";

        private readonly PizzaIngredientFactory pizzaIngredientFactory;

        public CheesePizza(PizzaIngredientFactory pizzaIngredientFactory)
        {
            this.pizzaIngredientFactory = pizzaIngredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");

            Sauce = pizzaIngredientFactory.CreateSauce("tomato");

            Cheeses.Add(pizzaIngredientFactory.CreateCheese("ementhal"));
            Cheeses.Add(pizzaIngredientFactory.CreateCheese("roquefort"));
            Cheeses.Add(pizzaIngredientFactory.CreateCheese("mozzarella"));
        }
    }
}
