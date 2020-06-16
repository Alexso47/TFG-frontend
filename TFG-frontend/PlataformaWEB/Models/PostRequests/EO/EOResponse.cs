using PlataformaWEB.Models.PostRequests.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.EO
{
    public class EOResponse : GenericResponse
    {
        public EOReferenceResponse Reference { get; set; }
    }
}
