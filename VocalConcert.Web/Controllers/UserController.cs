using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(vUserLogin model)
        {
            return View();
        }

        [Route("Register")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

    }
}