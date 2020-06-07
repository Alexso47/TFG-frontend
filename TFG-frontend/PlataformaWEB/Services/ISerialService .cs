using PlataformaWEB.Models;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface ISerialService
    { 
        public Task<PaginatedList<SerialReport>> GetFilteredSerials(SerialFilters filters);
    }
}
