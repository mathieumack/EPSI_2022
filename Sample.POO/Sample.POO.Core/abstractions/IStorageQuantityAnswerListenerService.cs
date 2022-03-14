using Sample.POO.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface IStorageQuantityAnswerListenerService
    {
        /// <summary>
        /// Wait for an answer for storage reference coun
        /// </summary>
        /// <param name="onEventReceived"></param>
        /// <returns></returns>
        Task StartListener(Action<StorageReferenceResponse> onEventReceived);
    }
}
