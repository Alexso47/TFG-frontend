using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.ReportToEmail
{
    public class ArrivalReportToEmail : ReportToEmail
    {
        public List<ArrivalReport> Items { get; set; }
    }
}
