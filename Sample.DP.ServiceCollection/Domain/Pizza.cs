using Sample.DP.ServiceCollection.Abstractions;

namespace Sample.DP.ServiceCollection.Domain
{
    internal abstract class Pizza
    {
        protected readonly ISaucesServices saucesServices;
        protected readonly ICheesesServices cheesesService;

        public abstract string Name { get; }

        protected Pizza(ISaucesServices saucesServices, ICheesesServices cheesesService)
        {
            this.saucesServices = saucesServices;
            this.cheesesService = cheesesService;
        }

        public Sauce Sauce { get; protected set; }

        public List<Cheese> Cheeses { get; protected set; } = new List<Cheese>();

        public abstract void Prepare();
    }
}
