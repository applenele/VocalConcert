﻿using System;
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

            _musics = db.Musics.OrderByDescending(m => m.Time).Skip(page * 10).Take(10).ToList();
            foreach (var music in _musics)
            {
                musics.Add(new vMusicList(music));
            }
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


        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Music music = new Music();
            music = db.Musics.Find(id);
            return View(music);
        }
    }
}