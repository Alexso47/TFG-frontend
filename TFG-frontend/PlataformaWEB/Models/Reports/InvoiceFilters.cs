using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class InvoiceFilters: DateFilters
    {
        public int? Id { get; set; }

        public bool BuyerEU { get; set; }

        public string BuyerID { get; set; }

        public float? Price { get; set; }

        public string Currency { get; set; }

        public string DocAction { get; set; }
        public string Email { get; set; }
        public string Interval { get; set; }
    }
}
