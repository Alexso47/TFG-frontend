using PlataformaWEB.Models.PostRequests.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Facility
{
    public class FacilityResponse : GenericResponse
    {
        public FacilityReferenceResponse Reference { get; set; }
    }
}
