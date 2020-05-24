using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaWEB.Controllers
{
    public class MonitoringController : Controller
    {
        public ActionResult Audittrail()
        {
            return View();
        }

        public ActionResult Subscriptions()
        {
            return View();
        }
    }
}