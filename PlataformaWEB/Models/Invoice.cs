using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Invoice
    {
        [Required]
        [Display(Name = "Número de factura")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Número de factura")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Display(Name = "Número de factura")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Número de factura")]
        public string Currency { get; set; }

        public bool BuyerEU { get; set; }

        public string BuyerID { get; set; }

        public string BuyerName { get; set; }

        public string BuyerCountry { get; set; }

        public string BuyerAddress { get; set; }

        public string BuyerCity { get; set; }

        public string BuyerZipCode { get; set; }

        public string Serials { get; set; }

        public List<string> SerialList { get; set; }

    }
}
   