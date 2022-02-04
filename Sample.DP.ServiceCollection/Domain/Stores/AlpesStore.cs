using Sample.DP.ServiceCollection.Abstractions;
using Sample.DP.ServiceCollection.Domain.Pizzas;

namespace Sample.DP.ServiceCollection.Domain.Stores
{
    internal class AlpesStore : PizzaStore
    {
        public override string Name => "Alpes";

        public AlpesStore(IPizzaIngredientService pizzaIngredientService, IServiceProvider serviceProvider)
            : base(pizzaIngredientService, serviceProvider)
        {
        }

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
                    return PreparePizza<KidPizza>();
                case "Cheese pizza":
                    return PreparePizza<CheesePizza>();
                default:
                    throw new InvalidOperationException($"{pizzaName} unknow");
            }
        }
    }
}
