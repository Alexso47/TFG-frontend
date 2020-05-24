using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaWEB.Controllers
{
    public class AdministrationController : Controller
    {
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ProductionLines()
        {
            return View();
        }
    }
}