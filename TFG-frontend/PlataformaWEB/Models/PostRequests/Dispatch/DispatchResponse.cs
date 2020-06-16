using PlataformaWEB.Models.PostRequests.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests
{
    public class DispatchResponse : GenericResponse
    {
        public DispatchReferenceResponse Reference { get; set; }
    }
}
