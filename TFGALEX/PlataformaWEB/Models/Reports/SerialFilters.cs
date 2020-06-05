using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class SerialFilters: DateFilters
    {
        public int? Id { get; set; }

        public string Serial { get; set; }
    }
}
