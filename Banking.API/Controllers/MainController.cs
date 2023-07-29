using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Banking.API.Controllers
{
    public class MainController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("main")]
        public ActionResult Main()
        {
            ViewBag.Title = "Main Page";


            return View();
        }
    }
}
