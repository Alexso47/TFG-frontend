using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Queries.Dispatch;
using Application.Queries.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("Summary")]
        [ProducesResponseType(typeof(PaginatedList<InvoiceResult>), 200)]
        public async Task<IActionResult> Summary([FromQuery] InvoiceQueryString queryString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new InvoiceQuery(
                queryString.CreationDateFrom,
                queryString.CreationDateTo,
                queryString.Id.Value,
                queryString.Price.Value,
                queryString.Currency,
                queryString.BuyerID,
                queryString.BuyerEU
                );

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
