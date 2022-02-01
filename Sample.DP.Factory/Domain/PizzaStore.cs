namespace Sample.DP.Factory.Domain
{
    internal abstract class PizzaStore
    {
        public abstract string Name { get; }

        protected readonly PizzaIngredientFactory ingredientFactory;

        protected PizzaStore()
        {
            ingredientFactory = new PizzaIngredientFactory();
        }

        public abstract List<string> GetAvailablePizzas();

        public abstract Pizza Order(string pizzaName);
    }
}
