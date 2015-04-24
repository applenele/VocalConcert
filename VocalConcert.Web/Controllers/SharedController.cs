using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VocalConcert.Web.Controllers
{
    public class SharedController : BaseController
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Message(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }
    }
}