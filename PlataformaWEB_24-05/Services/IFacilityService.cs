using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IFacilityService
    {
        Task<int> Create(Facility facility);

        Task<PaginatedList<string>> GetFIDs();

        Task<PaginatedList<string>> GetFIDsByEOID(string eoid);

        //Task<PaginatedList<Facility>> GetFacilityByFID(string fid);
    }
}
