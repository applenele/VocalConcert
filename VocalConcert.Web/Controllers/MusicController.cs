using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Helper;
using VocalConcert.Web.Models.ViewModel;

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
            typeList.Add(new SelectListItem { Text = MusicType.Original.ToString(), Value = "2", Selected = model.Type == MusicType.Original ? true : false });
            typeList.Add(new SelectListItem { Text = MusicType.Cover.ToString(), Value = "0", Selected = model.Type == MusicType.Cover ? true : false });
            typeList.Add(new SelectListItem { Text = MusicType.Instrument.ToString(), Value = "1", Selected = model.Type == MusicType.Instrument ? true : false });

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


        #region 获取歌曲
        /// <summary>
        /// 获取歌曲
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMusics(int page)
        {
            List<Music> _musics = new List<Music>();
            List<vMusicList> musics = new List<vMusicList>();

            _musics = db.Musics.OrderByDescending(m => m.Time).ToList();
            foreach (var music in _musics)
            {
                musics.Add(new vMusicList(music));
            }
            musics = musics.OrderByDescending(m => m.Score).Skip(page * 10).Take(10).ToList();
            return Json(musics);
        }
        #endregion


        #region 显示音乐
        /// <summary>
        /// 显示音乐
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Show(int id)
        {
            Music music = new Music();
            music = db.Musics.Find(id);

            return View(new vMusic(music));
        }
        #endregion

        #region 修改页面
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Music music = new Music();
            music = db.Musics.Find(id);

            List<SelectListItem> typeList = new List<SelectListItem>();
            typeList.Add(new SelectListItem { Text = MusicType.Original.ToString(), Value = "2", Selected = music.Type == MusicType.Original ? true : false });
            typeList.Add(new SelectListItem { Text = MusicType.Cover.ToString(), Value = "0", Selected = music.Type == MusicType.Cover ? true : false });
            typeList.Add(new SelectListItem { Text = MusicType.Instrument.ToString(), Value = "1", Selected = music.Type == MusicType.Instrument ? true : false });


            ViewBag.TypeList = typeList;
            return View(music);
        }
        #endregion

        #region 修改音乐
        /// <summary>
        ///  修改音乐
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult Edit(Music model, HttpPostedFileBase file)
        {

            Music music = new Music();
            music = db.Musics.Find(model.ID);
            music.Title = model.Title;
            music.Description = model.Description;
            music.Lyric = model.Lyric;

            if (file != null)
            {
                var fileName = Path.Combine(Request.MapPath("~/Upload"), DateHelper.GetTimeStamp() + Path.GetFileName(file.FileName));
                file.SaveAs(fileName);
                music.Path = DateHelper.GetTimeStamp() + Path.GetFileName(file.FileName);
            }

            music.RecommendMark = model.RecommendMark;
            music.TypeAsInt = model.TypeAsInt;
            int result = db.SaveChanges();
            if (result > 0)
            {
                return Redirect("/Music/Show/" + model.ID);
            }
            else
            {
                return Msg("修改音乐失败！请重试！");
            }
        }
        #endregion

        #region 下载
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Download(int id)
        {
            Music music = new Music();
            music = db.Musics.Find(id);
            var path = Server.MapPath("~/Upload/" + music.Path);
            return File(path, "1", Url.Encode(music.Path));
        }
        #endregion
    }
}