using Sample.POO.Core.Domain;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface IRequestStorageQuantityService
    {
        /// <summary>
        /// Request for a quantity
        /// </summary>
        /// <param name="storageReference"></param>
        /// <returns></returns>
        Task RequestForQuantity(StorageReferenceRequest storageReference);
    }
}
