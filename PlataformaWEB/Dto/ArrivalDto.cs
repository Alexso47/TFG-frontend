using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class ArrivalDTO
    {
        public RequestHeader RequestHeader { get; set; }
        public Arrival2FacilityReference Reference { get; set; }
        public string Comments { get; set; }
        public List<string> Serials { get; set; }
    }
    public class Arrival2FacilityReference
    { 
        public string FacilityID { get; set; }
        public DateTime EventTime { get; set; }
    }
}
