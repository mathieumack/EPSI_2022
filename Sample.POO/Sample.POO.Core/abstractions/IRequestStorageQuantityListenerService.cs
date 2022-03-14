using Sample.POO.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface IRequestStorageQuantityListenerService
    {
        /// <summary>
        /// Wait for storage listener events
        /// </summary>
        /// <param name="onEventReceived"></param>
        /// <returns></returns>
        Task StartListener();
    }
}
