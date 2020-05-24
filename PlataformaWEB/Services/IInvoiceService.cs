using PlataformaWEB.Models;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IInvoiceService
    {
        public Task<string> Register(Invoice invoice);

        public Task<List<InvoiceReport>> GetInvoices();
        
        public Task<List<InvoiceReport>> GetFilteredInvoices(DateFilters filters);

        
    }
}
