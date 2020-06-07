using System;
using System.Collections.Generic;
using System.Text;

namespace PlataformaWEB.Models
{
    public class InvoiceSerials
    {
        public int Id { get; set; }

        public string Serial { get; set; }

        public int InvoiceID { get; set; }
    }
}
