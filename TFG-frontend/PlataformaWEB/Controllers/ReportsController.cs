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
        private ISerialService _serialService;


        public ReportsController(IFacilityService facilityService, IArrivalService arrivalService, IInvoiceService invoiceService, IDispatchService dispatchService, ISerialService serialService)
        {
            _facilityService = facilityService;
            _arrivalService = arrivalService;
            _invoiceService = invoiceService;
            _dispatchService = dispatchService;
            _serialService = serialService;
        }

        // Arrival 
        [Route("~/ReportsController/Arrival")]
        public ActionResult Arrival()
        {
            var model = new ArrivalFilters();

            try
            {
                var arrivals = _arrivalService.GetFilteredArrivals(model);
                ViewBag.ArrivalsReport = arrivals.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las recepciones");
            }

            return View(model);
        }

        public ActionResult FilterArrival(ArrivalFilters filters)
        {
            try
            {
                var arrivals = _arrivalService.GetFilteredArrivals(filters);
                ViewBag.ArrivalsReport = arrivals.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las recepciones");
            }

            return View("Arrival", filters);
        }

        // Dispatch
        [Route("~/ReportsController/Dispatch")]
        [HttpGet]
        public ActionResult Dispatch()
        {
            var model = new DispatchFilters();
            try
            {
                var dispatches = _dispatchService.GetFilteredDispatches(model);
                ViewBag.DispatchesReport = dispatches.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los envíos");
            }
            return View(model);
        }

        public ActionResult FilterDispatch(DispatchFilters filters)
        {
            try
            {
                var dispatches = _dispatchService.GetFilteredDispatches(filters);
                ViewBag.DispatchesReport = dispatches.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los envíos");
            }
            return View("Dispatch",filters);
        }

        // Invoice 
        [Route("~/ReportsController/Invoice")]
        [HttpGet]
        public ActionResult Invoice()
        {
            var model = new InvoiceFilters();
            try
            {
                var invoices = _invoiceService.GetFilteredInvoices(model);
                ViewBag.InvoicesReport = invoices.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las facturas");
            }
            return View(model);
        }

        public ActionResult FilterInvoice(InvoiceFilters filters)
        {
            try
            {
                var invoices = _invoiceService.GetFilteredInvoices(filters);
                ViewBag.InvoicesReport = invoices.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las facturas");
            }
            return View("Invoice",filters);
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        // Serials
        [Route("~/ReportsController/Serial")]
        [HttpGet]
        public ActionResult Serial()
        {
            var model = new SerialFilters();
            try
            {
                var serials = _serialService.GetFilteredSerials(model);
                ViewBag.SerialsReport = serials.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los seriales");
            }
            return View(model);
        }

        public ActionResult FilterSerial(SerialFilters filters)
        {
            try
            {
                var serials = _serialService.GetFilteredSerials(filters);
                ViewBag.SerialsReport = serials.Result.Items;
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los seriales");
            }
            return View("Serial", filters);
        }
    }
}