using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;

namespace VocalConcert.Web.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        #region 显示图片
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult Icon(int id)
        {
            Product product = new Product();
            product = db.Products.Find(id);
            return File(product.Icon, "image/jpg");
        }
        #endregion

        #region 显示歌友会图标
        /// <summary>
        /// 显示歌友会图标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ShowGroupIcon(int id)
        {
            Group group = new Group();
            group = db.Groups.Find(id);
            return File(group.Icon, "image/jpg");
        } 
        #endregion


        #region 修改当地城市页面
        /// <summary>
        ///  修改当地城市
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeCity()
        {
            return View();
        } 
        #endregion

        /// <summary>
        /// 更多当地城市
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DoChangeCity(string city)
        {
            HttpContext.Session["City"] = city;
            return RedirectToAction("Index", "Home");
        }


    }

}