using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{
    public class ActionController : BaseController
    {
        // GET: Action
        public ActionResult Index()
        {
            return View();
        }


        #region 根据歌友会发起活动
        /// <summary>
        /// 根据歌友会发起活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Add(int id)
        {
            ViewBag.GroupID = id;
            return View();
        } 
        #endregion

        #region 执行发起活动
        /// <summary>
        /// 执行发起活动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Add(Entity.Action model)
        {
            ViewBag.GroupID = model.GroupID;
            if (ModelState.IsValid)
            {
                model.UserID = CurrentUser.ID;
                model.Time = DateTime.Now;
                db.Actions.Add(model);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ActionAttender at = new ActionAttender { ActionID = model.ID, UserID = CurrentUser.ID, Time = DateTime.Now };
                    db.ActionAttenders.Add(at);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "填写的信息出错！请重新填写！");
            }
            return View(model);
        } 
        #endregion



        #region 获取活动
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetActions(int page,string city)
        {
            List<Entity.Action> _actions = new List<Entity.Action>();
            List<vActionList> actions = new List<vActionList>();

            _actions = db.Actions.Where(a=>a.Address.Contains(city)).OrderByDescending(a => a.Time).Skip(page * 10).Take(10).ToList();
            foreach (var action in _actions)
            {
                actions.Add(new vActionList(action));
            }

            return Json(actions);
        } 
        #endregion


        #region 显示活动
        /// <summary>
        /// 显示活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            Entity.Action action = new Entity.Action();
            action = db.Actions.Find(id);
            return View(new vAction(action,CurrentUser==null?0:CurrentUser.ID));
        } 
        #endregion


        #region 参与活动
        /// <summary>
        /// 参与活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult Attend(int id)
        {
            int aid = id;
            int userId = CurrentUser.ID;
            ActionAttender aa = new ActionAttender();

            aa = db.ActionAttenders.Where(a => a.UserID == userId && a.ActionID == aid).SingleOrDefault();
            if (aa == null)
            {
                aa = new ActionAttender { UserID = userId, ActionID = aid, Time = DateTime.Now };
                db.ActionAttenders.Add(aa);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return Redirect("/Action/Show/" + id);
                }
                else
                {
                    return Msg("参与活动失败！请重试！");
                }
            }
            else
            {
                return Msg("你已经参与了该活动！");
            }

        } 
        #endregion



        #region 修改活动页面
        /// <summary>
        /// 修改活动页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Edit(int id)
        {
            Entity.Action action = new Entity.Action();
            action = db.Actions.Find(id);
            return View(action);
        } 
        #endregion

        #region 执行修改活动
        /// <summary>
        /// 执行修改活动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Entity.Action model)
        {
            if (ModelState.IsValid)
            {
                Entity.Action action = new Entity.Action();
                action = db.Actions.Find(model.ID);
                action.Title = model.Title;
                action.Description = model.Description;
                action.Begin = model.Begin;
                action.End = model.End;
                action.Address = model.Address;
                action.Hint = model.Hint;
                db.SaveChanges();
                return Redirect("/Action/Show/" + model.ID);
            }
            else
            {
                ModelState.AddModelError("", "修改的活动的信息不正确！请重试！");
            }
            return View();
        } 
        #endregion


        #region 当前用户退出活动
        /// <summary>
        /// 当前用户退出活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Quit(int aid,int uid)
        {
            ActionAttender aa = new ActionAttender();
            aa = db.ActionAttenders.Where(_aa => _aa.ActionID == aid && _aa.UserID == uid).SingleOrDefault();
            db.ActionAttenders.Remove(aa);
            db.SaveChanges();
            return Redirect("/Action/Show/"+aid);
        } 
        #endregion


        #region 删除活动 
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Entity.Action action = new Entity.Action();
            action = db.Actions.Find(id);
            db.Actions.Remove(action);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return Redirect("/Action/Index");
            }
            else
            {
                return Msg("删除活动失败！请重试!");
            }
        } 
        #endregion
    }
}