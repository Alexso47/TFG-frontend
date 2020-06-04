using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Arrivals
    {
        public int Id { get; set; }

        public string FID { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string Comments { get; set; }
    }
}
