using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IArrivalService
    {
        public Task<string> Register(Arrival arrival);

        public Task<PaginatedList<ArrivalReport>> GetArrivals();

        public Task<PaginatedList<ArrivalReport>> GetFilteredArrivals(ArrivalFilters filters);
    }
}
