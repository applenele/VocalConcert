using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using System.Net;
using System.IO;
using System.Text;

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

        #region 显示用户图标
        /// <summary>
        /// 显示用户图标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ShowUserIcon(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            return File(user.Avatar, "image/jpg");
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


        public ActionResult  GetWeather(string city)
        {
            var ret = "";
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities["齐齐哈尔"] = "http://www.weather.com.cn/adat/sk/101050201.html";
            cities["哈尔滨"] = "http://www.weather.com.cn/adat/sk/101050101.html";
            cities["大庆"] = "http://www.weather.com.cn/adat/sk/101050901.html";
            cities["沈阳"] = "http://www.weather.com.cn/adat/sk/101070101.html";
            var json = HttpGet(cities[city]);


            return RedirectToAction("Index", "Home");
        }

        private static string HttpGet(string Url)
        {
            string ret = string.Empty;
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(Url));
                webReq.Timeout = 3000;
                webReq.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }
            catch
            {
            }
            return ret;
        }



    }

}