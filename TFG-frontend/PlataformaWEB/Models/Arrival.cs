using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Arrival
    {
        [Required]
        [Display(Name = "Facility")]
        public string Facility { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Serials { get; set; }
        public List<string> SerialList { get; set; }
        public string Comments { get; set; }
    }
}
