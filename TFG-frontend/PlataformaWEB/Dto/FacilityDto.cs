using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class FacilityDto
    {
        public FacilityDto()
        {
        }

        public string Id { get; set; }

        public string EOID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTimeOffset ActiveFrom { get; set; }
    }
}
