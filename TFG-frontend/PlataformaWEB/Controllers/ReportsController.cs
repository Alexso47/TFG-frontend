using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Models;
using PlataformaWEB.Models.Reports;
using PlataformaWEB.Models.ReportToEmail;
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
        private IReportEmailService _reportToEmail;


        public ReportsController(IFacilityService facilityService, IArrivalService arrivalService, IInvoiceService invoiceService, IDispatchService dispatchService, ISerialService serialService, IReportEmailService reportToEmail)
        {
            _facilityService = facilityService;
            _arrivalService = arrivalService;
            _invoiceService = invoiceService;
            _dispatchService = dispatchService;
            _serialService = serialService;
            _reportToEmail = reportToEmail;
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
                ViewBag.Status = "";
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

                ViewBag.Status = "";

                string result = "";
                if (filters.DocAction == "Create" && filters.Email != null && filters.Email != "")
                {
                    result = CreateArrivalDocument((List<ArrivalReport>)arrivals.Result.Items, filters.Email, filters.Interval).Result;
                }
                else if(filters.DocAction == "Update" && filters.Email != null && filters.Email != "")
                {
                    result = UpdateArrivalDocument((List<ArrivalReport>)arrivals.Result.Items, filters.Email, filters.Interval).Result;
                }

                if(result == "OK")
                {
                    ViewBag.Status = "El documento se ha enviado a " + filters.Email + ". " +
                        "Puede tardar alrededor de un minuto en recibir el correo.";
                }
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
                ViewBag.Status = "";
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

                ViewBag.Status = "";

                string result = "";
                if (filters.DocAction == "Create" && filters.Email != null && filters.Email != "")
                {
                    result = CreateDispatchDocument((List<DispatchReport>)dispatches.Result.Items, filters.Email, filters.Interval).Result;
                }
                else if (filters.DocAction == "Update" && filters.Email != null && filters.Email != "")
                {
                    result = UpdateDispatchDocument((List<DispatchReport>)dispatches.Result.Items, filters.Email, filters.Interval).Result;
                }

                if (result == "OK")
                {
                    ViewBag.Status = "El documento se ha enviado a " + filters.Email + ". " +
                        "Puede tardar alrededor de un minuto en recibir el correo.";
                }
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

                ViewBag.Status = "";

                string result = "";
                if (filters.DocAction == "Create" && filters.Email != null && filters.Email != "")
                {
                    result = CreateInvoiceDocument((List<InvoiceReport>)invoices.Result.Items, filters.Email, filters.Interval).Result;
                }
                else if (filters.DocAction == "Update" && filters.Email != null && filters.Email != "")
                {
                    filters = FormatFilters(filters);
                    result = UpdateInvoiceDocument((List<InvoiceReport>)invoices.Result.Items, filters.Email, filters.Interval, filters).Result;
                }

                if (result == "OK")
                {
                    ViewBag.Status = "El documento se ha enviado a " + filters.Email + ". " +
                        "Puede tardar alrededor de un minuto en recibir el correo.";
                }
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo las facturas");
            }
            return View("Invoice",filters);
        }

        public InvoiceFilters FormatFilters(InvoiceFilters filters)
        {
            if (filters.Id == null) { filters.Id = 0; }
            if (filters.Price == null) { filters.Price = 0; }
            if (filters.BuyerID == null) { filters.BuyerID = ""; }
            if (filters.Currency == null) { filters.Currency = ""; }
            return filters;
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

                ViewBag.Status = "";

                string result = "";
                if (filters.DocAction == "Create" && filters.Email != null && filters.Email != "")
                {
                    result = CreateSeriaDocument((List<SerialReport>)serials.Result.Items, filters.Email, filters.Interval).Result;
                }
                else if (filters.DocAction == "Update" && filters.Email != null && filters.Email != "")
                {
                    result = UpdateSeriaDocument((List<SerialReport>)serials.Result.Items, filters.Email, filters.Interval).Result;
                }

                if (result == "OK")
                {
                    ViewBag.Status = "El documento se ha enviado a " + filters.Email + ". " +
                        "Puede tardar alrededor de un minuto en recibir el correo.";
                }
            }
            catch
            {
                throw new RequestErrorException("Error obteniendo los seriales");
            }
            return View("Serial", filters);
        }





        // ********* REPORTS TO EMAIL *********

        // ARRIVALS
        public async Task<string> CreateArrivalDocument(List<ArrivalReport> arrivalReports, string email, string interval)
        {
            try
            {
                var report = new ArrivalReportToEmail
                {
                    Items = arrivalReports,
                    Email = email,
                    Interval = interval
                };
                
                var result = await _reportToEmail.CreateArrivalReportToEmail(report);

                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error creando el documento de recepciones");
            }
        }

        public async Task<string> UpdateArrivalDocument(List<ArrivalReport> results, string email, string interval)
        {
            try
            {
                var report = new ArrivalReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.UpdateArrivalReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        // DISPATCH
        [Route("~/ReportsController/CreateDispatchDocument")]
        [HttpPost]
        public async Task<string> CreateDispatchDocument(List<DispatchReport> results, string email, string interval)
        {
            try
            {
                var report = new DispatchReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.CreateDispatchReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        [Route("~/ReportsController/UpdateDispatchDocument")]
        [HttpPost]
        public async Task<string> UpdateDispatchDocument(List<DispatchReport> results, string email, string interval)
        {
            try
            {
                var report = new DispatchReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.UpdateDispatchReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        // INVOICE
        [Route("~/ReportsController/CreateInvoiceDocument")]
        [HttpPost]
        public async Task<string> CreateInvoiceDocument(List<InvoiceReport> results, string email, string interval)
        {
            try
            {
                var report = new InvoiceReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.CreateInvoiceReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        [Route("~/ReportsController/UpdateInvoiceDocument")]
        [HttpPost]
        public async Task<string> UpdateInvoiceDocument(List<InvoiceReport> results, string email, string interval, InvoiceFilters filters)
        {
            try
            {
                var report = new InvoiceReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval,
                    Filters = filters
                };

                var result = await _reportToEmail.UpdateInvoiceReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        // SERIAL
        [Route("~/ReportsController/CreateSerialDocument")]
        [HttpPost]
        public async Task<string> CreateSeriaDocument(List<SerialReport> results, string email, string interval)
        {
            try
            {
                var report = new SerialReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.CreateSerialReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }

        [Route("~/ReportsController/UpdateSerialDocument")]
        [HttpPost]
        public async Task<string> UpdateSeriaDocument(List<SerialReport> results, string email, string interval)
        {
            try
            {
                var report = new SerialReportToEmail
                {
                    Items = results,
                    Email = email,
                    Interval = interval
                };

                var result = await _reportToEmail.UpdateSerialReportToEmail(report);


                if (result == "OK")
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException("Error actualizando el documento de recepciones");
            }
        }
    }
}