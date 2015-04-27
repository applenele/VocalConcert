﻿using System;
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
        public string CurrentCity { get; set; }
        public BaseController() { }


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                CurrentUser = (from u in db.Users
                               where u.Username == User.Identity.Name
                               select u).SingleOrDefault();
                ViewBag.CurrentUser = CurrentUser;
                Role = CurrentUser.Role;
                ViewBag.Role = Role;
            }
            CurrentCity = this.HttpContext.Session["City"] == null ? "齐齐哈尔" : Session["City"].ToString();
            ViewBag.CurrentCity = CurrentCity;
        }
        protected ActionResult Msg(string msg)
        {
            return RedirectToAction("Message", "Shared", new { msg = msg });
        }
    }
}