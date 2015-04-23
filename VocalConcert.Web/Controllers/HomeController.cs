using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VocalConcert.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {
            Entity.User user = new Entity.User { Username = "admin", Password = "111111" };
            db.Users.Add(user);
            db.SaveChangesAsync();
            return View();
        }



    }
}