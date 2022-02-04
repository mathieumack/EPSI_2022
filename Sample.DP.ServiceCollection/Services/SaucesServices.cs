using Sample.DP.ServiceCollection.Abstractions;
using Sample.DP.ServiceCollection.Domain;
using Sample.DP.ServiceCollection.Domain.Ingredients.Sauces;

namespace Sample.DP.ServiceCollection.Services
{
    internal class SaucesServices : ISaucesServices
    {
        private readonly IServiceProvider serviceProvider;

        public SaucesServices(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Sauce Create(string sauceName)
        {
            switch (sauceName)
            {
                case "tomato":
                    return (TomatoSauce)serviceProvider.GetService(typeof(TomatoSauce));
                default:
                    throw new InvalidOperationException($"{sauceName} unknow");
            }
        }
    }
}
