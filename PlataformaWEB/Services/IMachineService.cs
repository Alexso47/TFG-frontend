using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public interface IMachineService
    {
        Task<int> Create(Machine machine);

        Task<PaginatedList<string>> GetMIDs();

        Task<PaginatedList<string>> GetMIDsByFID(string fid);

        Task<PaginatedList<string>> GetProductsNameByMID(string mid);

        //Task<PaginatedList<Facility>> GetMachineByMID(string mid);
    }
}
