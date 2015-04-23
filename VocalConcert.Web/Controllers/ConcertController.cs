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


        #region 增肌歌友会

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
        public async Task<ActionResult> Add(vGroupAdd model)
        {
            if (ModelState.IsValid)
            {
                Group group = new Group();
                group.Title = model.Title;
                group.Description = model.Description;
                group.City = model.City;
                group.Time = DateTime.Now;
                group.UserID = CurrentUser.ID;
                db.Groups.Add(group);
                int result = await db.SaveChangesAsync();
                if (result > 0)
                {
                    return RedirectToAction("Index", "Concert");
                }
                else
                {
                    ModelState.AddModelError("", "增加歌友会失败，请重新发起!");
                }
            }
            else
            {
                ModelState.AddModelError("", "发起信息填写错误，请重新填写!");
            }
            return View();
        } 
        #endregion
    }
}