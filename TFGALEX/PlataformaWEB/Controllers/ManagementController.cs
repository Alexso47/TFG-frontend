using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlataformaWEB.Models;
using PlataformaWEB.Services;
using PlataformaWEB.Exceptions;

namespace PlataformaWEB.Controllers
{
    public class ManagementController : Controller
    {
        private IEconomicOperatorService _economicOperatorService;
        private IFacilityService _facilityService;
        private IMachineService _machineService;
        private IRequestService _requestService;

        public ManagementController(IEconomicOperatorService economicOperatorService, IFacilityService facilityService, IMachineService machineService, IRequestService requestService)
        {
            _economicOperatorService = economicOperatorService;
            _facilityService = facilityService;
            _machineService = machineService;
            _requestService = requestService;
        }

        // EconomicOperator 
        [Route("~/ManagementController/EconomicOperator")]
        [HttpGet]
        public ActionResult EconomicOperator()
        {
            var model = new EconomicOperator();

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            return View("EconomicOperators", model);
        }

        [Route("~/ManagementController/EditEconomicOperator")]
        [HttpGet]
        public async Task<IActionResult> EditEconomicOperator(string eoid)
        {
            //var model = new EconomicOperator();
            //try
            //{
            //    model = await _economicOperatorService.GetEconomicOperatorByEOID(eoid);
            //    if (model == null)
            //    {
            //        BadRequest(eoid);
            //    }
            //    return Json(new { status = "OK", data = model });
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { status = "ERROR", data = ex.Message });
            //}
            if(eoid == "EOID1")
            {
                var model = new EconomicOperator
                {
                    Id = eoid,
                    Name = "Prueba1",
                    Description = "Prueba 1 sin acceder a la API",
                    Address = "Calle TFG, 8",
                    ZipCode = "08181",
                    Country = "España",
                    City = "Sentmenat",
                    ActiveFrom = DateTime.Now.AddDays(-1)
                };

                return Json(new { status = "OK", data = model });
            }
            else
            {
                return Json(new { status = "ERROR", data = "error" });
            } 
        }

        [Route("~/ManagementController/EconomicOperator")]
        [HttpPost]
        public async Task<ActionResult> EconomicOperator(EconomicOperator economicOperator)
        {
            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            if (ModelState.IsValid)
            {
                try
                {
                    int newEconomicOperatorId = await _economicOperatorService.Create(economicOperator);
                    economicOperator.Id = newEconomicOperatorId.ToString();
                }
                catch
                {
                    throw new RequestErrorException("Error creando el Economic Operator");
                }
            }
            return View("EconomicOperators",economicOperator);
        }


        // Facilities 
        [Route("~/ManagementController/Facility")]
        [HttpGet]
        public ActionResult Facility()
        {
            var model = new Facility();

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            return View("Facilities", model);
        }

        [Route("~/ManagementController/SetFIDs")]
        [HttpGet]
        public IActionResult SetFIDs(string eoid)
        {
            var fids = GetFIDS(eoid);
            var items = FillDropDown(fids.Items);
            return Json(items);
        }

        [Route("~/ManagementController/EditFacility")]
        [HttpGet]
        public async Task<IActionResult> EditFacility(string fid)
        {
            //var model = new Facility();
            //try
            //{
            //    model = await _facilityService.GetFacilityByFID(fid);
            //    if (model == null)
            //    {
            //        BadRequest(eoid);
            //    }
            //    return Json(new { status = "OK", data = model });
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { status = "ERROR", data = ex.Message });
            //}
            if (fid == "FID1")
            {
                var model = new Facility
                {
                    EOID = "EOID1",
                    Id = fid,
                    Name = "Prueba1",
                    Description = "Prueba 1 sin acceder a la API",
                    Address = "Calle TFG, 8",
                    ZipCode = "08181",
                    Country = "España",
                    City = "Sentmenat",
                    ActiveFrom = DateTime.Now.AddDays(-1)
                };

                return Json(new { status = "OK", data = model });
            }
            else
            {
                return Json(new { status = "ERROR", data = "error" });
            }
        }

        [Route("~/ManagementController/Facility")]
        [HttpPost]
        public async Task<ActionResult> Facility(Facility facility)
        {
            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            if (ModelState.IsValid)
            {
                try
                {
                    int newFacilityId = await _facilityService.Create(facility);
                    facility.Id = newFacilityId.ToString();
                }
                catch
                {
                    throw new RequestErrorException("Error creando el Facility ");
                }
            }
            return View("Facilities", facility);
        }

        // Machines
        [Route("~/ManagementController/Machine")]
        [HttpGet]
        public ActionResult Machine()
        {
            var model = new Machine();

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            var mids = GetMIDS("");
            ViewBag.MIDs = FillDropDown(mids.Items);

            return View("Machines", model);
        }

        [Route("~/ManagementController/SetMIDs")]
        [HttpGet]
        public IActionResult SetMIDs(string fid)
        {
            var mids = GetMIDS(fid);
            var items = FillDropDown(mids.Items);
            return Json(items);
        }

        [Route("~/ManagementController/EditMachine")]
        [HttpGet]
        public async Task<IActionResult> EditMachine(string mid)
        {
            //var model = new Machine();
            //try
            //{
            //    model = await _machineService.GetMachineByMID(mid);
            //    if (model == null)
            //    {
            //        BadRequest(eoid);
            //    }
            //    return Json(new { status = "OK", data = model });
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { status = "ERROR", data = ex.Message });
            //}
            if (mid == "CokeM1")
            {
                var model = new Machine
                {
                    EOID = "EOID1",
                    FID = "FID1",
                    Id = mid,
                    Name = "Prueba1",
                    Description = "Prueba 1 sin acceder a la API",
                    Producer = "CocaCola",
                    Serial = "coke19520eo1f1asdloki",
                    ActiveFrom = DateTime.Now.AddDays(-1)
                };

                return Json(new { status = "OK", data = model });
            }
            else
            {
                return Json(new { status = "ERROR", data = "error" });
            }
        }
        [Route("~/ManagementController/Machine")]
        [HttpPost]
        public async Task<ActionResult> Machine(Machine machine)
        {
            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            var mids = GetMIDS("");
            ViewBag.MIDs = FillDropDown(mids.Items);

            if (ModelState.IsValid)
            {
                try
                {
                    int newMachineId = await _machineService.Create(machine);
                    machine.Id = machine.ToString();
                }
                catch
                {
                    throw new RequestErrorException("Error creando la Machine ");
                }
            }

            return View("Machines", machine);
        }

        // Requests
        [Route("~/ManagementController/Request")]
        [HttpGet]
        public async Task<ActionResult> Request()
        {
            var model = new Request();

            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            var mids = GetMIDS("");
            ViewBag.MIDs = FillDropDown(mids.Items);

            var products = GetProductsName("");
            ViewBag.Products = FillDropDown(products.Items);

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            return View("Requests", model);
        }

        [Route("~/ManagementController/SetProducts")]
        [HttpGet]
        public IActionResult SetProducts(string mid)
        {
            var mids = GetProductsName(mid);
            var items = FillDropDown(mids.Items);
            return Json(items);
        }

        [Route("~/ManagementController/Request")]
        [HttpPost]
        public async Task<ActionResult> Request(Request request)
        {
            var eoids = GetEOIDS();
            ViewBag.EOIDs = FillDropDown(eoids.Items);

            var fids = GetFIDS("");
            ViewBag.FIDs = FillDropDown(fids.Items);

            var mids = GetMIDS("");
            ViewBag.MIDs = FillDropDown(mids.Items);

            var products = GetProductsName("");
            ViewBag.Products = FillDropDown(products.Items);

            var countries = GetCountries();
            ViewBag.Countries = CountriesFillDropDown(countries.Items);

            if (ModelState.IsValid)
            {
                try
                {
                    int newMachineId = await _requestService.Create(request);
                    request.Id = request.ToString();
                }
                catch
                {
                    throw new RequestErrorException("Error creando el Request ");
                }
            }

            return View("Requests", request);
        }

        private PaginatedList<Country> GetCountries()
        {
            Country spain = new Country("España");
            Country germany = new Country("Alemania");
            Country france = new Country("Francia");
            Country portugal = new Country("Portugal");
            Country italy = new Country("Italia");
            List<Country> countries = new List<Country>();
            countries.Add(germany);
            countries.Add(spain);
            countries.Add(france);
            countries.Add(italy);
            countries.Add(portugal);

            var countriesPL = new PaginatedList<Country>()
            {
                Items = countries
            };
            return countriesPL;
        }

        // DropDowns
        private PaginatedList<string> GetEOIDS()
        {
            List<string> eoids = new List<string>();
            eoids.Add("EOID1");
            eoids.Add("EOID2");
            eoids.Add("EOID3");
            eoids.Add("EOID4");
            eoids.Add("EOID5");

            var eoidsPL = new PaginatedList<string>()
            {
                Items = eoids
            };

            return eoidsPL;
        }

        private PaginatedList<string> GetFIDS(string eoid)
        {
            List<string> fids = new List<string>();
            fids.Add("FID1");
            fids.Add("FID2");
            fids.Add("FID3");
            fids.Add("FID4");
            fids.Add("FID5");

            var fidsPL = new PaginatedList<string>()
            {
                Items = fids
            };
            if (eoid == "EOID1")
            {
                return fidsPL;
            }
            else
            {
                return new PaginatedList<string>();
            }
        }

        private PaginatedList<string> GetMIDS(string fid)
        {
            List<string> mids = new List<string>();
            mids.Add("CokeM1");
            mids.Add("RedbullM2");
            mids.Add("SpriteM3");

            var midsPL = new PaginatedList<string>()
            {
                Items = mids
            };

            if (fid == "FID1")
            {
                return midsPL;
            }
            else
            {
                return new PaginatedList<string>();
            }
        }

        private PaginatedList<string> GetProductsName(string mid)
        {
            List<string> products = new List<string>();
            products.Add("Coca Cola");
            products.Add("Coca Cola Zero");
            products.Add("Coca Cola Light");

            var productsPL = new PaginatedList<string>()
            {
                Items = products
            };

            if (mid == "CokeM1")
            {
                return productsPL;
            }
            else
            {
                return new PaginatedList<string>();
            }
        }


        //API DEVELOPEMENT
        //private async Task<PaginatedList<string>> GetCountries()
        //{
        //    PaginatedList<string> countries = await _countryService.GetCountriesName();
        //    return countries;
        //}

        //private async Task<PaginatedList<string>> GetEOIDS()
        //{
        //    PaginatedList<string> eoids = await _economicOperatorService.GetEOIDs();
        //    return eoids;
        //}

        //private async Task<PaginatedList<string>> GetFIDS(string eoid)
        //{
        //    PaginatedList<string> fids = await _facilityService.GetFIDsByEOID(eoid);
        //    return fids;
        //}

        //private async Task<PaginatedList<string>> GetMIDS(string fid)
        //{
        //    PaginatedList<string> mids = await _machineService.GetMIDsByFID(fid);
        //    return mids;
        //}

        //private async Task<PaginatedList<string>> GetProductsName(string mid)
        //{
        //    PaginatedList<string> productsName = await _machineService.GetProductsNameByMID(mid);
        //    return productsName;
        //}

        // Filling dropdowns

        private List<SelectListItem> FillDropDown(IEnumerable<string> list)
        {
            var aux = new List<SelectListItem>();
            var white = new SelectListItem("", "");
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
            var white = new SelectListItem("", "");
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