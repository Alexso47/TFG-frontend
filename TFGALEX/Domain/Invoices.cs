using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Invoices
    {
        public string Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Currency { get; set;}

        public bool BuyerEU { get; set; }

        public string BuyerId { get; set; }
    }
}
