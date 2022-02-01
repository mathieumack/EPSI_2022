using Sample.DP.Factory.Domain.Ingredients.Cheeses;
using Sample.DP.Factory.Domain.Ingredients.Sauces;

namespace Sample.DP.Factory.Domain
{
    internal class PizzaIngredientFactory
    {
        public Sauce CreateSauce(string sauceName)
        {
            switch(sauceName)
            {
                case "tomato":
                    return new TomatoSauce();
                default:
                    throw new InvalidOperationException($"{sauceName} unknow");
            }
        }

        public Cheese CreateCheese(string cheeseName)
        {
            switch (cheeseName)
            {
                case "ementhal":
                    return new EmmenthalCheese();
                case "roquefort":
                    return new RoquefortCheese();
                case "mozzarella":
                    return new MozzarellaCheese();
                default:
                    throw new InvalidOperationException($"{cheeseName} unknow");
            }
        }
    }
}
