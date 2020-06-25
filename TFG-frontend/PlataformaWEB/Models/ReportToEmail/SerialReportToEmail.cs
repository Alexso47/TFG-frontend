using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.ReportToEmail
{
    public class SerialReportToEmail : ReportToEmail
    {
        public List<SerialReport> Items { get; set; }
    }
}
