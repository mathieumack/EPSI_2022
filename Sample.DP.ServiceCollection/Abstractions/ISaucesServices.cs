using Sample.DP.ServiceCollection.Domain;

namespace Sample.DP.ServiceCollection.Abstractions
{
    internal interface ISaucesServices
    {
        /// <summary>
        /// Create a sauce by his name
        /// </summary>
        /// <param name="sauceName"></param>
        /// <returns></returns>
        Sauce Create(string sauceName);
    }
}
