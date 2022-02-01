namespace Sample.DP.Factory.Domain.Pizzas
{
    internal class KidPizza : Pizza
    {
        public override string Name => "Cheese pizza";

        private readonly PizzaIngredientFactory pizzaIngredientFactory;

        public KidPizza(PizzaIngredientFactory pizzaIngredientFactory)
        {
            this.pizzaIngredientFactory = pizzaIngredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");

            Sauce = pizzaIngredientFactory.CreateSauce("tomato");

            Cheeses.Add(pizzaIngredientFactory.CreateCheese("ementhal"));
        }
    }
}
