using Sample.DP.ServiceCollection.Abstractions;
using Sample.DP.ServiceCollection.Domain;
using Sample.DP.ServiceCollection.Domain.Ingredients.Cheeses;

namespace Sample.DP.ServiceCollection.Services
{
    internal class CheesesServices : ICheesesServices
    {
        private readonly IServiceProvider serviceProvider;

        public CheesesServices(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Cheese Create(string cheeseName)
        {
            switch (cheeseName)
            {
                case "ementhal":
                    return (EmmenthalCheese)serviceProvider.GetService(typeof(EmmenthalCheese));
                case "roquefort":
                    return (RoquefortCheese)serviceProvider.GetService(typeof(RoquefortCheese));
                case "mozzarella":
                    return (MozzarellaCheese)serviceProvider.GetService(typeof(MozzarellaCheese));
                default:
                    throw new InvalidOperationException($"{cheeseName} unknow");
            }
        }
    }
}
