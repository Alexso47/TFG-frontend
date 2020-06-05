using Domain;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISerialService
    {
        Task<List<Serials>> GetSerials(SerialFilter filter);

        Task<int> GetTotalSerials(SerialFilter filter);
    }
}
