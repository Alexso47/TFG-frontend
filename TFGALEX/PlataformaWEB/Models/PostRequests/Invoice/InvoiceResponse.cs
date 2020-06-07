using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Invoice
{
    public class InvoiceResponse : GenericResponse
    {
        public InvoiceReferenceResponse Reference { get; set; }
    }
}
