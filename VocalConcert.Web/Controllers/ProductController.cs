using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 增加优惠产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        #region 增加优惠产品
        /// <summary>
        /// 增加优惠产品
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Add(Product model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    System.IO.Stream stream = file.InputStream;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    stream.Close();
                    model.Icon = buffer;
                    model.UserID = CurrentUser.ID;
                    model.Time = DateTime.Now;
                    db.Products.Add(model);
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        return Redirect("/User/" + CurrentUser.ID);
                    }
                    else
                    {
                        ModelState.AddModelError("", "增加优惠产品失败！");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "图标不能为空！");
                }
            }
            else
            {
                ModelState.AddModelError("", "产品信息填写有误请重新填写!");
            }

            return View(model);
        }
        #endregion



        #region 得到优惠产品
        /// <summary>
        ///   得到优惠产品
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetProducts(int page)
        {
            List<Product> products = new List<Product>();
            List<vProductList> _products = new List<vProductList>();
            products = db.Products.OrderByDescending(p => p.Time).Skip(page * 10).Take(10).ToList();
            foreach (var product in products)
            {
                _products.Add(new vProductList(product));
            }
            return Json(_products);
        }
        #endregion


        #region 显示产品信息
        /// <summary>
        /// 显示产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            Product product = new Product();
            product = db.Products.Find(id);
            return View(product);
        } 
        #endregion


       
    }
}