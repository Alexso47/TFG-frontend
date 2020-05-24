using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class InvoiceReport
    { 
        public string Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float Price { get; set; }

        public string Currency { get; set; }

        public bool BuyerEU { get; set; }

        public string BuyerID { get; set; }

        public string BuyerName { get; set; }

        public string BuyerCountry { get; set; }

        public string BuyerAddress { get; set; }

        public string BuyerCity { get; set; }

        public string BuyerZipCode { get; set; }

        public List<InvoiceReport> Elements { get; set; }

        public DateFilters DateFilters { get; set; }
    }
}
