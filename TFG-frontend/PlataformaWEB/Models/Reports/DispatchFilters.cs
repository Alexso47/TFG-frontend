using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class DispatchFilters : DateFilters
    { 
        public int? Id { get; set; }

        public string FID { get; set; }

        public bool DestinationEU { get; set; }

        public string DestinationFID { get; set; }

        public string TransportMode { get; set; }

        public string Vehicle { get; set; }

        public string DocAction { get; set; }
        public string Email { get; set; }
        public string Interval { get; set; }

    }
}
