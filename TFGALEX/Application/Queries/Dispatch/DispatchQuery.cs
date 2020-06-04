using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Dispatch
{
    public class DispatchQuery : IRequest<PaginatedList<DispatchResult>>
    {
        public DispatchQuery(DateTime? dateFrom, DateTime? dateTo, int id, string fid, string destinationFID, string transportMode, string vehicle, bool? destinationEU)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            Id = id;
            FID = fid;
            DestinationFID = destinationFID;
            TransportMode = transportMode;
            Vehicle = vehicle;
            DestinationEU = destinationEU;
        }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? Id { get; set; }

        public string FID { get; set; }

        public bool? DestinationEU { get; set; }

        public string DestinationFID { get; set; }

        public string TransportMode { get; set; }

        public string Vehicle { get; set; }
    }
}
