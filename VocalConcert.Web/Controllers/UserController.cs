using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VocalConcert.Web.Models;
using VocalConcert.Web.Models.ViewModel;

namespace VocalConcert.Web.Controllers
{

    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            Entity.User user = new Entity.User { Username = "admin", Password = "111111" };
            db.Users.Add(user);
            db.SaveChangesAsync();
            return View();
        }


        #region 登陆页面
        /// <summary>
        ///   登陆页面
        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        } 
        #endregion


        #region 登陆
        /// <summary>
        /// 登陆操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(vUserLogin model)
        {
            if (ModelState.IsValid)
            {

                Entity.User user = new Entity.User();
                model.Password = Helper.Encryt.GetMD5(model.Password);
                user = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "用户名或者密码不正确！");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "验证失败！请重新登陆！");
            }
            return View(model);
        } 
        #endregion

        #region 注册页面
        [Route("Register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        } 
        #endregion

        #region 注册
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register(vUserRegister model)
        {
            if (ModelState.IsValid)
            {
                Entity.User user = new Entity.User();
                user = db.Users.Where(u => u.Username == model.Username).FirstOrDefault();
                if (user != null)
                {
                    ModelState.AddModelError("", "该用户名已经存在");
                }
                else
                {
                    user = new Entity.User();
                    user.Username = model.Username;
                    user.Password = Helper.Encryt.GetMD5(model.Username);
                    user.Phone = model.Password;
                    user.Phone = model.Phone;
                    db.Users.Add(user);
                    int result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "注册失败！");
                    }
                }
            }
            return View(model);
        }
        #endregion


        public ActionResult Show(int id)
        {
            Entity.User user =new  Entity.User();
            user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }
    }
}