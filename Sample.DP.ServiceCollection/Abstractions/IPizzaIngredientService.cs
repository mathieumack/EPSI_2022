using Sample.DP.ServiceCollection.Domain;

namespace Sample.DP.ServiceCollection.Abstractions
{
    internal interface IPizzaIngredientService
    {
        /// <summary>
        /// Create a sauce by his name
        /// </summary>
        /// <param name="sauceName"></param>
        /// <returns></returns>
        Sauce CreateSauce(string sauceName);

        /// <summary>
        /// Create a cheese by his name
        /// </summary>
        /// <param name="cheeseName"></param>
        /// <returns></returns>
        Cheese CreateCheese(string cheeseName);
    }
}
