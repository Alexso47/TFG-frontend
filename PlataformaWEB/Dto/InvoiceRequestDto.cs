using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class InvoiceRequestDto
    {
        public string Id { get; set; }

        public RequestHeader RequestHeader { get; set; }

        public InvoiceReferenceRequestDto Invoice { get; set; }

        public List<string> Serials { get; set; }
    }
}
