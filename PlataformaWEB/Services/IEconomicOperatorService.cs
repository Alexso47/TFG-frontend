using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaWEB.Models;

namespace PlataformaWEB.Services
{
    public interface IEconomicOperatorService
    {
        Task<int> Create(EconomicOperator economicOperator);

        Task<PaginatedList<string>> GetEOIDs();

        //Task<PaginatedList<string>> GetEconomicOperators();

        Task<EconomicOperator> GetEconomicOperatorByEOID(string eoid);

    }
}
