using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{
    public class ConcertController : BaseController
    {
        // GET: Concert
        public ActionResult Index()
        {
            return View();
        }


        #region 增加歌友会

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        #endregion


        #region 发起歌友会
        /// <summary>
        /// 发起歌友会
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Add(vGroupAdd model,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Group group = new Group();
                    System.IO.Stream stream = file.InputStream;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    stream.Close();
                   
                    group.Title = model.Title;
                    group.Description = model.Description;
                    group.City = model.City;
                    group.Time = DateTime.Now;
                    group.UserID = CurrentUser.ID;
                    group.Icon = buffer;
                    db.Groups.Add(group);
                    int result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        int groupId = group.ID;
                        int userId = CurrentUser.ID;
                        GroupMember gm = new GroupMember { GroupID = groupId, UserID = userId, Time = DateTime.Now };
                        db.GroupMembers.Add(gm);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Concert");
                    }
                    else
                    {
                        ModelState.AddModelError("", "增加歌友会失败，请重新发起!");
                    }
                }
                else
                {
                    ModelState.AddModelError("","图标文件不能为空！");
                }
            }
            else
            {
                ModelState.AddModelError("", "发起信息填写错误，请重新填写!");
            }
            return View();
        }
        #endregion


        #region 获取歌友会
        /// <summary>
        /// 获取歌友会
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetConcerts(int page)
        {
            List<Group> _groups = new List<Group>();
            List<vGroupList> groups = new List<vGroupList>();


            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            _groups = db.Groups.OrderByDescending(c => c.Time).Skip(page * 10).Take(10).ToList();
            foreach (var group in _groups)
            {
                groups.Add(new vGroupList(group));
            }

            return Json(groups);
        }
        #endregion


        #region 显示歌友会
        /// <summary>
        /// 显示歌友会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Show(int id)
        {
            Group group = new Group();
            group = db.Groups.Find(id);
            ViewBag.Group = new vGroup(group);
            return View(new vGroup(group));
        }
        #endregion


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Group group = new Group();
            group = db.Groups.Find(id);
            ViewBag.Group = new vGroup(group);
            return View(new vGroup(group));
        }


        #region 执行修改
        /// <summary>
        /// 执行修改 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Edit(vGroup model,HttpPostedFileBase file)
        {
            Group group = new Group();
            group = db.Groups.Find(model.ID);
            if (file != null)
            {
                System.IO.Stream stream = file.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                stream.Close();
                group.Icon = buffer;
            }
            group.Title = model.Title;
            group.Description = model.Description;
            group.City = model.City;
            db.SaveChanges();
            return Redirect("/Concert/Show/" + model.ID);
        }
        #endregion


        /// <summary>
        ///  加入歌友会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Attend(int id)
        {
            int userId = CurrentUser.ID;
            GroupMember _gm = new GroupMember();
            _gm = db.GroupMembers.Where(gm => gm.UserID == userId && gm.GroupID == id).SingleOrDefault();
            if (_gm == null)
            {
                _gm = new GroupMember();
                _gm.GroupID = id;
                _gm.UserID = userId;
                _gm.Time = DateTime.Now;
                db.GroupMembers.Add(_gm);
                int result = await db.SaveChangesAsync();
                if (result > 0)
                {
                    return Redirect("/Concert/Show/" + id);
                }
                else
                {
                    return Msg("加入歌友会失败！");
                }
            }
            else
            {
                return Msg("你已经是该歌友会的成员！");
            }
        }
    }
}