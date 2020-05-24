using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class InvoiceReferenceRequestDto
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
    }
}
