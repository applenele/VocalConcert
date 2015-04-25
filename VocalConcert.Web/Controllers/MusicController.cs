using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Helper;

namespace VocalConcert.Web.Controllers
{
    public class MusicController : BaseController
    {
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 上传音乐页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Upload()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            typeList.Add(new SelectListItem { Text = MusicType.Cover.ToString(), Value = "0", Selected = false });
            typeList.Add(new SelectListItem { Text = MusicType.Instrument.ToString(), Value = "1", Selected = false });
            typeList.Add(new SelectListItem { Text = MusicType.Original.ToString(), Value = "2", Selected = false });
            ViewBag.TypeList = typeList;
            return View();
        }

        #region 上传操作
        /// <summary>
        /// 上传操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Upload(Music model, HttpPostedFileBase file)
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            typeList.Add(new SelectListItem { Text = MusicType.Cover.ToString(), Value = "0", Selected = false });
            typeList.Add(new SelectListItem { Text = MusicType.Instrument.ToString(), Value = "1", Selected = false });
            typeList.Add(new SelectListItem { Text = MusicType.Original.ToString(), Value = "2", Selected = false });
            ViewBag.TypeList = typeList;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Entity.User user = CurrentUser;
                    var fileName = Path.Combine(Request.MapPath("~/Upload"), DateHelper.GetTimeStamp() + Path.GetFileName(file.FileName));
                    try
                    {
                        file.SaveAs(fileName);
                        Music music = new Music { Title = model.Title, Description = model.Description, Lyric = model.Lyric, UserID = CurrentUser.ID, RecommendMark = model.RecommendMark, Path = DateHelper.GetTimeStamp() + Path.GetFileName(file.FileName), Time = DateTime.Now, TypeAsInt = model.TypeAsInt };
                        db.Musics.Add(music);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Music");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "上传文件出错");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "上传文件出错");
                }
            }
            else
            {
                ModelState.AddModelError("", "上传文件出错");
            }
            return View(model);
        } 
        #endregion
    }
}