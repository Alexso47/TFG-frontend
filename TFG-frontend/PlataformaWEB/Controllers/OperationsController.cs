using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Models;
using PlataformaWEB.Services;

namespace PlataformaWEB.Controllers
{
    public class OperationsController : Controller
    {
       
        private IFacilityService _facilityService;
        private IArrivalService _arrivalService;
        private IInvoiceService _invoiceService;
        private IDispatchService _dispatchService;
                

        public OperationsController(IFacilityService facilityService, IArrivalService arrivalService, IInvoiceService invoiceService, IDispatchService dispatchService)
        {
            _facilityService = facilityService;
            _arrivalService = arrivalService;
            _invoiceService = invoiceService;
            _dispatchService = dispatchService;
        }

        // Arrival 
        [Route("~/OperationsController/Arrival")]
        [HttpGet]
        public ActionResult Arrival()
        {
            var arrival = new Arrival();

            var facilities = GetFIDS();
            if(facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }

            ViewBag.Status = "";

            return View(arrival);
        }

        [Route("~/OperationsController/Arrival")]
        [HttpPost]
        public async Task<ActionResult> Arrival(Arrival arrival)
        {
            try
            {
                if (arrival.Serials == null || arrival.Serials.Count() == 0)
                {
                    throw new Exception("No hay seriales definidos");
                }

                arrival.SerialList = arrival.Serials.Split("/n").ToList();
                var result = await _arrivalService.Register(arrival);
                
                if (result.ResponseResult.Errors == null)
                {
                    ViewBag.Status = "Recepcion con ID " + result.Reference.ArrivalNumber + " registrada";
                    arrival = new Arrival();
                }
                else
                {
                    ViewBag.Status = result.ResponseResult.Errors.FirstOrDefault().ErrorMessage;
                    arrival = new Arrival();
                    ViewBag.Serials = arrival.SerialList;
                    ViewBag.JsonSerials = JsonConvert.SerializeObject(arrival.SerialList);
                }
            }
            catch(Exception ex)
            {
                throw new RequestErrorException(ex.Message);
            }

            var facilities = GetFIDS();
            if (facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }
            ModelState.Clear();
            return View(arrival);
        }

        // Dispatch 
        [Route("~/OperationsController/Dispatch")]
        [HttpGet]
        public ActionResult Dispatch()
        {
            var dispatch = new Dispatch();

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            ViewBag.Status = "";

            var facilities = GetFIDS();
            if (facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }

            return View(dispatch);
        }

        [Route("~/OperationsController/Dispatch")]
        [HttpPost]
        public async Task<ActionResult> Dispatch(Dispatch dispatch)
        {
            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);
           
            try
            {
                if (dispatch.Serials == null || dispatch.Serials.Count() == 0)
                {
                    throw new Exception("No hay seriales definidos");
                }

                dispatch.SerialList = dispatch.Serials.Split("/n").ToList();
                var result = await _dispatchService.RegisterDispatch(dispatch);

                if (result.ResponseResult.Errors == null)
                {
                    ViewBag.Status = "La recepcion con ID " + dispatch.Facility + " registrada";
                    dispatch = new Dispatch();
                }
                else
                {
                    dispatch = new Dispatch();
                    ViewBag.Status = result.ResponseResult.Errors.FirstOrDefault().ErrorMessage;
                    ViewBag.Serials = dispatch.SerialList;
                    ViewBag.JsonSerials = JsonConvert.SerializeObject(dispatch.SerialList);
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException(ex.Message);
            }
            ModelState.Clear();

            var facilities = GetFIDS();
            if (facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }
            return View(dispatch);
        }

        // Invoice
        [Route("~/OperationsController/Invoice")]
        [HttpGet]
        public ActionResult Invoice()
        {
            var invoice = new Invoice();

            var currencies = GetCurrencies();
            ViewBag.Currencies = FillDropDown(currencies.Items);

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            ViewBag.Status = "";

            invoice.SerialList = new List<string>();

            invoice.Serials = "";

            var facilities = GetFIDS();
            if (facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }

            return View(invoice);
        }
        
        [Route("~/OperationsController/Invoice")]
        [HttpPost]
        public async Task<ActionResult> Invoice(Invoice invoice)
        {
            var currencies = GetCurrencies();
            ViewBag.Currencies = FillDropDown(currencies.Items);

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);
            try
            {
                if (ModelState.IsValid)
                {
                    if (invoice.Serials == null || invoice.Serials.Count() == 0)
                    {
                        throw new Exception("No hay seriales definidos");
                    }

                    invoice.SerialList = invoice.Serials.Split("/n").ToList();
                    var result = await _invoiceService.Register(invoice);

                    if (result.ResponseResult.Errors == null)
                    {
                        ViewBag.Status = "Factura con ID " + invoice.Id + " registrada";
                        invoice = new Invoice();
                    }
                    else
                    {
                        ViewBag.Status = result.ResponseResult.Errors.FirstOrDefault().ErrorMessage;
                        invoice = new Invoice();
                        invoice.SerialList = new List<string>();
                        invoice.Serials = "";
                        ViewBag.JsonSerials = JsonConvert.SerializeObject(invoice.SerialList);
                    }
                }
                else
                {
                    throw new Exception("Los campos necesarios no son correctos");
                }
            }
            catch (Exception ex)
            {
                throw new RequestErrorException(ex.Message);
            }
            ModelState.Clear();

            var facilities = GetFIDS();
            if (facilities.Result != null)
            {
                ViewBag.Facilities = FillDropDown(facilities.Result);
            }
            else
            {
                ViewBag.Facilities = new List<SelectListItem>();
            }

            return View(invoice);
        }
        

        // **** To Develop
        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
        // ****


        //API CALLS
        private async Task<List<string>> GetFIDS()
        {
            List<string> fids = await _facilityService.GetFIDs();
            return fids;
        }

        //Sets
        private PaginatedList<Country> GetCountries()
        {
            Country andorra = new Country("Andorra");
            Country brasil = new Country("Brasil");
            Country canada = new Country("Canadá");
            Country japon = new Country("Japón");
            Country usa = new Country("USA");
            List<Country> countries = new List<Country>();
            countries.Add(andorra);
            countries.Add(brasil);
            countries.Add(canada);
            countries.Add(japon);
            countries.Add(usa);

            var countriesPL = new PaginatedList<Country>()
            {
                Items = countries
            };
            return countriesPL;
        }
        private PaginatedList<string> GetCurrencies()
        {
            List<string> currencies = new List<string>();
            currencies.Add("EUR");
            currencies.Add("USD");
            currencies.Add("GBP");

            var currenciesPL = new PaginatedList<string>()
            {
                Items = currencies
            };

            return currenciesPL;
        }

        private List<SelectListItem> FillDropDown(IEnumerable<string> list)
        {
            var aux = new List<SelectListItem>();
            var white = new SelectListItem("- Selecciona -", "");
            aux.Add(white);
            if (list != null)
            {
                foreach (var item in list)
                {
                    var id = new SelectListItem(item, item);
                    aux.Add(id);
                }
                return aux;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        private List<SelectListItem> CountriesFillDropDown(IEnumerable<Country> list)
        {
            var countries = new List<SelectListItem>();
            var white = new SelectListItem("- Selecciona -", "");
            countries.Add(white);
            foreach (var item in list)
            {
                var country = new SelectListItem(item.Name, item.Name);
                countries.Add(country);
            }
            return countries;
        }
    }
}