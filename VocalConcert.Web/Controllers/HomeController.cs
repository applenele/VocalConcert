using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Group> _groups = new List<Group>();
            List<vGroup> groups = new List<vGroup>();
            List<vGroup> groups2 = new List<vGroup>();
           // List<GroupMember> _gms = new List<GroupMember>();
            _groups = db.Groups.OrderByDescending(g => g.Time).Take(10).ToList();
            foreach (var group in _groups)
            {
                groups.Add(new vGroup(group));
            }

            var _gms = (from gm in db.GroupMembers
                    group gm by gm.Group into g orderby g.Count() descending select new {Group=g.Key,Count=g.Count()}).Take(10).ToList();

            foreach (var gm in _gms)
            {
                groups2.Add(new vGroup(gm.Group));
            }

            ViewBag.Groups = groups;
            ViewBag.Groups2 = groups2;
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