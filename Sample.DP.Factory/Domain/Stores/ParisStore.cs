using Sample.DP.Factory.Domain.Pizzas;

namespace Sample.DP.Factory.Domain.Stores
{
    internal class ParisStore : PizzaStore
    {
        public override string Name => "Paris";

        public override List<string> GetAvailablePizzas()
        {
            return new List<string>()
            {
                "Kid pizza"
            };
        }

        public override Pizza Order(string pizzaName)
        {
            switch (pizzaName)
            {
                case "Kid pizza":
                    var pizza = new KidPizza(ingredientFactory);
                    pizza.Prepare();
                    return pizza;
                default:
                    throw new InvalidOperationException($"{pizzaName} unknow");
            }
        }
    }
}
