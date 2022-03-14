using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.POO.Core.Domain
{
    public class StorageReferenceResponse
    {
        /// <summary>
        /// Asked reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Number of reference in stock
        /// </summary>
        public int Quantity { get; set; }
    }
}
