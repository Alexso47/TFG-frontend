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

        public string FID { get; set; }

        public DateTimeOffset ArrivalDate { get; set; }

        public string Comments { get; set; }

        public List<string> Serials { get; set; }
    }
}
