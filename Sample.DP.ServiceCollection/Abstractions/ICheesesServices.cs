using Sample.DP.ServiceCollection.Domain;

namespace Sample.DP.ServiceCollection.Abstractions
{
    internal interface ICheesesServices
    {
        /// <summary>
        /// Create a cheese by his name
        /// </summary>
        /// <param name="cheeseName"></param>
        /// <returns></returns>
        Cheese Create(string cheeseName);
    }
}
