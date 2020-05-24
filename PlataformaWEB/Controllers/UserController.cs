using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaWEB.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Configuration()
        {
            return View();
        }
    }
}