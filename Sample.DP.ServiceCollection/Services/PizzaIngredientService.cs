using Sample.DP.ServiceCollection.Abstractions;
using Sample.DP.ServiceCollection.Domain;

namespace Sample.DP.ServiceCollection.Services
{
    internal class PizzaIngredientService : IPizzaIngredientService
    {
        private readonly ICheesesServices cheesesServices;
        private readonly ISaucesServices saucesServices;

        public PizzaIngredientService(ICheesesServices cheesesServices, ISaucesServices saucesServices)
        {
            this.cheesesServices = cheesesServices;
            this.saucesServices = saucesServices;
        }

        public Cheese CreateCheese(string cheeseName)
        {
            return cheesesServices.Create(cheeseName);
        }

        public Sauce CreateSauce(string sauceName)
        {
            return saucesServices.Create(sauceName);
        }
    }
}
