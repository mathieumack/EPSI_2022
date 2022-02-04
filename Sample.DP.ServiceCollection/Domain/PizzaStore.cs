using Sample.DP.ServiceCollection.Abstractions;

namespace Sample.DP.ServiceCollection.Domain
{
    internal abstract class PizzaStore
    {
        public abstract string Name { get; }

        protected readonly IPizzaIngredientService pizzaIngredientService;
        private readonly IServiceProvider serviceProvider;

        protected PizzaStore(IPizzaIngredientService pizzaIngredientService, IServiceProvider serviceProvider)
        {
            this.pizzaIngredientService = pizzaIngredientService;
            this.serviceProvider = serviceProvider;
        }

        public abstract List<string> GetAvailablePizzas();

        public abstract Pizza Order(string pizzaName);

        protected Pizza PreparePizza<T>() where T : Pizza
        {
            T? pizza = serviceProvider.GetService(typeof(T)) as T;

            if (pizza is null)
                throw new InvalidOperationException($"The type {typeof(T)} is not registered.");

            pizza.Prepare();

            return pizza;
        }
    }
}
