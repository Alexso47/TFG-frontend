using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaWEB.Controllers
{
    public class HomeController : Controller
    {
        // Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}