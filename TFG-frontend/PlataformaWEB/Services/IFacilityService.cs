using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IFacilityService
    {
        Task<FacilityResponse> Create(Facility facility);

        Task<List<string>> GetFIDs();

        Task<List<string>> GetFIDsByEOID(string eoid);

        Task<FacilityResult> GetFacilityByFID(string fid);
    }
}
