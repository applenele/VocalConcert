using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VocalConcert.Entity;
using VocalConcert.Web.Models;

namespace VocalConcert.Web.Controllers
{
    public class BaseController : Controller
    {
        public DB db = new DB();
        public User CurrentUser = null;
        public UserRole? Role = null;

        public BaseController() { }


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = (from u in db.Users
                               where u.Username == User.Identity.Name
                               select u).Single();
                ViewBag.CurrentUser = CurrentUser;
                Role = CurrentUser.Role;
                ViewBag.Role = Role;
            }
        }
        protected ActionResult Msg(string msg)
        {
            return RedirectToAction("Message", "Shared", new { msg = msg });
        }
    }
}