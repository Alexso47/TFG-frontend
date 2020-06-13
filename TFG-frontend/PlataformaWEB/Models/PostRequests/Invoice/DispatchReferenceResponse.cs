using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models.PostRequests.Dispatch
{
    public class DispatchReferenceResponse
    {
        public string DispatchNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? DispatchDate { get; set; }
    }
}
