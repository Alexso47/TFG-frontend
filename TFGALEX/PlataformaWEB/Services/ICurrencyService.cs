using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaWEB.Models;

namespace PlataformaWEB.Services
{
    public interface ICurrencyService
    {
        Task<PaginatedList<string>> GetCurrencies();
    }
}

