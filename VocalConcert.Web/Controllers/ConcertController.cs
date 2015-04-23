using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VocalConcert.Web.Controllers
{
    public class ConcertController : Controller
    {
        // GET: Concert
        public ActionResult Index()
        {
            return View();
        }
    }
}