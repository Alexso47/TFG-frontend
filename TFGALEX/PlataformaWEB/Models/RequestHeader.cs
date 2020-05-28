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
        /// <summary>
        /// Gets or sets the client code.
        /// </summary>
        /// <value>
        /// The client code.
        /// </value>
        public string ClientCode { get; set; }
        /// <summary>
        /// Gets or sets the stakeholder code.
        /// </summary>
        /// <value>
        /// The stakeholder code.
        /// </value>
        public string StakeholderCode { get; set; }
        /// <summary>
        /// Gets or sets the date request. Format YYYYMMDD
        /// </summary>
        /// <value>
        /// The date request.
        /// </value>
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
