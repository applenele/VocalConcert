using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VocalConcert.Models;

namespace VocalConcert.Controllers
{
    public class BaseController : Controller
    {
        public readonly VocalConcertContext DB = new VocalConcertContext();
        public User CurrentUser = null;
        public UserRole? Role = null;
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = (from u in DB.Users
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