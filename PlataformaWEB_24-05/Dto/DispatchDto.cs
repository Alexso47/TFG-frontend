using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class DispatchDto
    {
        public string Facility { get; set; }

        public DateTimeOffset DispatchDate { get; set; }

        public int? DestinationEU { get; set; }

        public List<string> DestinationFacilities { get; set; }

        public string DestinationName { get; set; }

        public string DestinationCountry { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationZipCode { get; set; }

        public List<string> Serials { get; set; }

        public int TransportMode { get; set; }

        public string Vehicle { get; set; }
    }
}
