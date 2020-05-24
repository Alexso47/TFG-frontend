using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Dto
{
    public class RequestDto
    {
        public string Id { get; set; }

        public string FID { get; set; }

        public string EOID { get; set; }

        public string MID { get; set; }

        public string ProductName { get; set; }
        
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Market { get; set; }

        public string Route { get; set; }
        
        public int Quantity { get; set; }

        public string MLine { get; set; }

        public string Comments { get; set; }
    }
}
