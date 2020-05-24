using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Dispatch
    {
        [Required]
        [Display(Name = "Facility del envío")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Facility { get; set; }

        [Required]
        [Display(Name = "Fecha de envío")]
        public DateTimeOffset DispatchDate { get; set; }

        [Required]
        [Display(Name = "Hora de envío")]
        public string DispatchHour { get; set; }

        [Required]
        public double UTCminutes { get; set; }

        public bool DestinationEU { get; set; }

        public string DestinationFacilities { get; set; }

        public List<string> DestinationFacilitiesList { get; set; }

        public string DestinationName { get; set; }

        public string DestinationCountry { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationZipCode { get; set; }

        public string Serials { get; set; }

        public List<string> SerialList { get; set; }

        public int TransportMode { get; set; }

        public string Vehicle { get; set; }
    }
}
