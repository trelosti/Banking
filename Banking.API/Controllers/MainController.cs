using Banking.API.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.API.Controllers
{
    public class MainController : Controller
    {
        [Authorize]
        public ActionResult Main()
        {
            return View();
        }
    }
}