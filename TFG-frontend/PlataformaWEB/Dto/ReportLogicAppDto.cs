using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class ReportLogicAppDto
    {
        public string Email { get; set; }

        public byte IsNewFile { get; set; }

        public string NewFileName { get; set; }

        public RequestHeader RequestHeader { get; set; }
    }
}
