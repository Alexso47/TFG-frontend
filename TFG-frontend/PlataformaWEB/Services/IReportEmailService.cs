using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Arrival;
using PlataformaWEB.Models.ReportToEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IReportEmailService
    {
        public Task<string> CreateArrivalReportToEmail(ArrivalReportToEmail results);
        public Task<string> UpdateArrivalReportToEmail(ArrivalReportToEmail results);

        public Task<string> CreateDispatchReportToEmail(DispatchReportToEmail results);
        public Task<string> UpdateDispatchReportToEmail(DispatchReportToEmail results);

        public Task<string> CreateInvoiceReportToEmail(InvoiceReportToEmail results);
        public Task<string> UpdateInvoiceReportToEmail(InvoiceReportToEmail results);

        public Task<string> CreateSerialReportToEmail(SerialReportToEmail results);
        public Task<string> UpdateSerialReportToEmail(SerialReportToEmail results);
    }
}
