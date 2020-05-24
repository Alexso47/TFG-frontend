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
    }
}
