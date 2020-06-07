using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Invoice;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IInvoiceService
    {
        public Task<InvoiceResponse> Register(Invoice invoice);

        public Task<PaginatedList<InvoiceReport>> GetInvoices();
        
        public Task<PaginatedList<InvoiceReport>> GetFilteredInvoices(InvoiceFilters filters);

        
    }
}
