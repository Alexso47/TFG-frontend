using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Exceptions
{
    public class RequestErrorException : Exception
    {
        public RequestErrorException(string message) : base(message) { }
    }
}
