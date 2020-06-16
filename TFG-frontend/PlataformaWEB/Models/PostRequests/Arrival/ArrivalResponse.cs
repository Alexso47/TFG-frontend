using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Arrival
{
    public class ArrivalResponse : GenericResponse
    {
        public ArrivalReferenceResponse Reference { get; set; }
    }
}
