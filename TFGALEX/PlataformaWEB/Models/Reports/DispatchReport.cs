using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class DispatchReport
    {
        public string Facility { get; set; }

        public DateTime DispatchDate { get; set; }

        public string DispatchHour { get; set; }

        public double UTCminutes { get; set; }

        public bool DestinationEU { get; set; }

        public string DestinationFacilities { get; set; }

        public List<string> DestinationFacilitiesList { get; set; }

        public string DestinationName { get; set; }

        public string DestinationCountry { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationZipCode { get; set; }

        public List<string> SerialList { get; set; }

        public int TransportMode { get; set; }

        public string Vehicle { get; set; }

        public List<DispatchReport> Elements { get; set; }

        public DateFilters DateFilters { get; set; }
    }
}
