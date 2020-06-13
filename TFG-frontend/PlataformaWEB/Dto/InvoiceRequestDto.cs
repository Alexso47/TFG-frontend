using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class InvoiceRequestDto : InvoiceReferenceRequestDto
    {
        public RequestHeader RequestHeader { get; set; }

        public List<string> Serials { get; set; }
    }
}
