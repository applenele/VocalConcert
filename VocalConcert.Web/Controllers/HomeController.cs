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

            List<Music> _musics = new List<Music>();
            List<vMusic> musics1 = new List<vMusic>();
            List<vMusic> musics2 = new List<vMusic>();

            List<Product> _products = new List<Product>();
            List<vProduct> products = new List<vProduct>();

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


            //最新10音乐
            _musics = db.Musics.OrderByDescending(m => m.Time).Take(10).ToList();
            foreach (var music in _musics)
            {
                musics1.Add(new vMusic(music));
            }
            //评分最高10音乐
            _musics = db.Musics.OrderByDescending(m => m.Time).ToList();
            foreach (var music in _musics)
            {
                musics2.Add(new vMusic(music));
            }
            musics2 = musics2.OrderByDescending(m => m.Score).Take(10).ToList();

            ///最新10个优惠产品
            _products = db.Products.OrderByDescending(p => p.Time).Take(10).ToList();
            foreach (var product in _products)
            {
                products.Add(new vProduct(product));
            }

            ViewBag.Groups = groups;
            ViewBag.Groups2 = groups2;
            ViewBag.Actions = actions1;
            ViewBag.Actions2 = actions2;

            ViewBag.Musics1 = musics1;
            ViewBag.Musics2 = musics2;

            ViewBag.Products = products;
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