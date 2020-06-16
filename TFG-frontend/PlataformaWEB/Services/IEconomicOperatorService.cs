using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.EO;

namespace PlataformaWEB.Services
{
    public interface IEconomicOperatorService
    {
        Task<EOResponse> Create(EconomicOperator economicOperator);

        Task<List<string>> GetEOIDS();

        //Task<PaginatedList<string>> GetEconomicOperators();

        Task<EOResult> GetEconomicOperatorByEOID(string eoid);

    }
}
