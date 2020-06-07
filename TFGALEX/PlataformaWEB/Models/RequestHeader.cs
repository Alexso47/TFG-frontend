using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    /// <summary>
    /// Class RequestHeader
    /// </summary>
    public class RequestHeader
    {
        public string DateRequest { get; set; }
        /// <summary>
        /// Gets or sets the time request. Format HHMMSS
        /// </summary>
        /// <value>
        /// The time request.
        /// </value>
        public string TimeRequest { get; set; }
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public string RequestId { get; set; }
    }
}
