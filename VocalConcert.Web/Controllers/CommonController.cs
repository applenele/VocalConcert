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
    }
}