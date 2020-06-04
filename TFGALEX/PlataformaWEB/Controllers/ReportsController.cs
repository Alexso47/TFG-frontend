using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Models;
using PlataformaWEB.Models.Reports;
using PlataformaWEB.Services;

namespace PlataformaWEB.Controllers
{
    public class ReportsController : Controller
    {
        private IFacilityService _facilityService;
        private IArrivalService _arrivalService;
        private IInvoiceService _invoiceService;
        private IDispatchService _dispatchService;


        public ReportsController(IFacilityService facilityService, IArrivalService arrivalService, IInvoiceService invoiceService, IDispatchService dispatchService)
        {
            _facilityService = facilityService;
            _arrivalService = arrivalService;
            _invoiceService = invoiceService;
            _dispatchService = dispatchService;
        }

        // Arrival 
        [Route("~/ReportsController/Arrival")]
        public ActionResult Arrival()
        {
            var model = new ArrivalReport();

            ArrivalReport a1 = new ArrivalReport { Facility = "Fabrica 1", Comments= "ASDFGHJKLMNBVCXZQWERTYUIOP/nASDFGHJKLMNBVCXZQWERTYUIOP/nASDFGHJKLMNBVCXZQWERTYUIOP/n" };
            ArrivalReport a2 = new ArrivalReport { Facility = "Fabrica 3", Comments= "ASDFGHJKLMNBVCXZQWERTYUIOP/nASDFGHJKLMNBVCXZQWERTYUIOP/nASDFGHJKLMNBVCXZQWERTYUIOP/n" };
            model.Elements = new List<ArrivalReport> { a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2, a1, a2};

            //try
            //{
            //    var dispatches = _dispatchService.GetDispatches();
            //    model.Elements = dispatches.Result;
            //}
            //catch
            //{
            //    throw new RequestErrorException("Error obteniendo las facturas");
            //}
            return View(model);
        }

        public ActionResult Delivery()
        {
            return View();
        }

        // Dispatch
        [Route("~/ReportsController/Dispatch")]
        [HttpGet]
        public ActionResult Dispatch()
        {
            var model = new DispatchFilters();
            ViewBag.DispatchesReport = new List<DispatchReport>();
            return View(model);
        }

        public ActionResult FilterDispatch(DispatchFilters filters)
        {
            var model = new DispatchFilters();

            try
            {
                var dispatches = _dispatchService.GetFilteredDispatches(filters);
                ViewBag.DispatchesReport = dispatches.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los envíos");
            }
            return View("Dispatch",model);
        }

        // Invoice 
        [Route("~/ReportsController/Invoice")]
        [HttpGet]
        public ActionResult Invoice()
        {
            var model = new InvoiceReport();

            InvoiceReport i1 = new InvoiceReport { Id = "1", InvoiceDate = DateTime.Now, Price = 6, Currency = "Euros" };
            InvoiceReport i2 = new InvoiceReport { Id = "2", InvoiceDate = DateTime.Now.AddDays(1), Price = 4, Currency = "Euros" };
            model.Elements = new List<InvoiceReport> { i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2, i1, i2 };

            //try
            //{
            //    var invoices = _invoiceService.GetInvoices();
            //    model.Elements = invoices.Result;
            //}
            //catch
            //{
            //    throw new RequestErrorException("Error obteniendo las facturas");
            //}
            return View(model);
        }

        public ActionResult FilterInvoice(InvoiceReport invoiceReport)
        {
            var model = new InvoiceReport();

            try
            {
                var invoices = _invoiceService.GetFilteredInvoices(invoiceReport.DateFilters);
                model.Elements = invoices.Result;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las facturas");
            }
            return View(model);
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Serial()
        {
            return View();
        }
    }
}