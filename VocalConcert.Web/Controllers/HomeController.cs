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
            List<Entity.Action> _actions = new List<Entity.Action>();
            List<vAction> actions1 = new List<vAction>();
            List<vAction> actions2 = new List<vAction>();
            // List<GroupMember> _gms = new List<GroupMember>();

            //最新10条歌友会
            _groups = db.Groups.OrderByDescending(g => g.Time).Take(10).ToList();
            foreach (var group in _groups)
            {
                groups.Add(new vGroup(group));
            }

            //热门歌友会排名前十
            var _gms = (from gm in db.GroupMembers
                        group gm by gm.Group into g
                        orderby g.Count() descending
                        select new { Group = g.Key, Count = g.Count() }).Take(10).ToList();

            foreach (var gm in _gms)
            {
                groups2.Add(new vGroup(gm.Group));
            }

            //最新10活动
            _actions = db.Actions.OrderByDescending(a => a.Title).Take(10).ToList();
            foreach (var action in _actions)
            {
                actions1.Add(new vAction(action));
            }

            //最热活动前十条
            var _as = (from aa in db.ActionAttenders
                       group aa by aa.Action into a
                       orderby a.Count() descending
                       select new { action = a.Key, Count = a.Count() }).Take(10).ToList();

            foreach (var aa in _as)
            {
                actions2.Add(new vAction(aa.action));
            }
            ViewBag.Groups = groups;
            ViewBag.Groups2 = groups2;
            ViewBag.Actions = actions1;
            ViewBag.Actions2 = actions2;
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