using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.ReportToEmail
{
    public class InvoiceReportToEmail : ReportToEmail
    {
        public List<InvoiceReport> Items { get; set; }
        public InvoiceFilters Filters { get; set; }
    }
}
