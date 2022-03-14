using Sample.POO.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface ISendStorageQuantityService
    {
        /// <summary>
        /// Send a storage quantity depending on reference
        /// </summary>
        /// <param name="storageReference"></param>
        /// <returns></returns>
        Task SendStorageQuantity(StorageReferenceRequest storageReference);
    }
}
