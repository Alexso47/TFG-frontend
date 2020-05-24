using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class MachineDto
    {
        public MachineDto()
        {
        }

        public string Id { get; set; }

        public string EOID { get; set; }
        
        public string FID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public string Serial { get; set; }

        public DateTime ActiveFrom { get; set; }
    }
}
