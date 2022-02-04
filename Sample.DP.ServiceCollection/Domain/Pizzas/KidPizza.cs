using Sample.DP.ServiceCollection.Abstractions;

namespace Sample.DP.ServiceCollection.Domain.Pizzas
{
    internal class KidPizza : Pizza
    {
        public override string Name => "Cheese pizza";

        public KidPizza(ISaucesServices saucesServices, ICheesesServices cheesesService)
            : base(saucesServices, cheesesService)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");

            Sauce = saucesServices.Create("tomato");

            Cheeses.Add(cheesesService.Create("ementhal"));
        }
    }
}
