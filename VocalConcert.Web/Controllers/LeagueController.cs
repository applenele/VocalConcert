using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VocalConcert.Web.Controllers
{
    public class LeagueController : BaseController
    {
        // GET: League
        public ActionResult Index()
        {
            return View();
        }
    }
}