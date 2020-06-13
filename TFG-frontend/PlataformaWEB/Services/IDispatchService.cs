using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IDispatchService
    {
        public Task<DispatchResponse> RegisterDispatch(Dispatch dispatch);

        public Task<List<DispatchReport>> GetDispatches();

        public Task<PaginatedList<DispatchReport>> GetFilteredDispatches(DispatchFilters filters);
    }
}
