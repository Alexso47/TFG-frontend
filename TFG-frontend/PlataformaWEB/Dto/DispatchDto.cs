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

        public byte DestinationEU { get; set; }

        public string DestinationFacility { get; set; }

        public string DestinationName { get; set; }

        public string DestinationCountry { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationZipCode { get; set; }

        public string TransportMode { get; set; }

        public string Vehicle { get; set; }

        public List<string> Serials { get; set; }

        public RequestHeader RequestHeader { get; set; }
    }
}
