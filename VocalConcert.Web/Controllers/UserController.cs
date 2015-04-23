using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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


        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(vUserLogin model)
        {
            if (ModelState.IsValid)
            {


            }
            return View(model);
        }

        [Route("Register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

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

    }
}