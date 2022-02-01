using Sample.DP.Factory.Domain.Pizzas;

namespace Sample.DP.Factory.Domain.Stores
{
    internal class AlpesStore : PizzaStore
    {
        public override string Name => "Alpes";

        public override List<string> GetAvailablePizzas()
        {
            return new List<string>()
            {
                "Cheese pizza",
                "Kid pizza"
            };
        }

        public override Pizza Order(string pizzaName)
        {
            switch (pizzaName)
            {
                case "Kid pizza":
                    var kidPizza = new KidPizza(ingredientFactory);
                    kidPizza.Prepare();
                    return kidPizza;
                case "Cheese pizza":
                    var cheesePizza = new CheesePizza(ingredientFactory);
                    cheesePizza.Prepare();
                    return cheesePizza;
                default:
                    throw new InvalidOperationException($"{pizzaName} unknow");
            }
        }
    }
}
