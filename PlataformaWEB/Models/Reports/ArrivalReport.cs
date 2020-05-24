using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class ArrivalReport
    {
        public string Facility { get; set; }

        public List<string> SerialList { get; set; }

        public string Comments { get; set; }

        public List<ArrivalReport> Elements { get; set; }
    }
}
