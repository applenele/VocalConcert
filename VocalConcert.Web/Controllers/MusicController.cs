using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}