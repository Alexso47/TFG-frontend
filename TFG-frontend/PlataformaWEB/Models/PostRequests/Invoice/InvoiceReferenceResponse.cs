using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Invoice
{
    public class InvoiceReferenceResponse
    {
        public string InvoiceNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? InvoiceDate { get; set; }
    }
}
