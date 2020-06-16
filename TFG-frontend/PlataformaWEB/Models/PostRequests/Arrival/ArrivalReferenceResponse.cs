using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Arrival
{
    public class ArrivalReferenceResponse
    {
        public string ArrivalNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? ArrivalDate { get; set; }
    }
}
