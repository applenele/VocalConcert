using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VocalConcert.Entity;
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
        public ActionResult Login(vUserLogin model, string returnUrl)
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
                    return Redirect(returnUrl ?? "/Home/Index");
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
            List<SelectListItem> RoleList = new List<SelectListItem>();
            RoleList.Add(new SelectListItem { Text = "普通用户", Value = "0", Selected = true });
            RoleList.Add(new SelectListItem { Text = "商户", Value = "2", Selected = false });
            ViewBag.RoleList = RoleList;
            return View();
        }
        #endregion

        #region 注册
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register(vUserRegister model)
        {
            List<SelectListItem> RoleList = new List<SelectListItem>();
            RoleList.Add(new SelectListItem { Text = "普通用户", Value = "0", Selected = true });
            RoleList.Add(new SelectListItem { Text = "商户", Value = "2", Selected = false });
            ViewBag.RoleList = RoleList;
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
                    user.Password = Helper.Encryt.GetMD5(model.Password);
                    user.Phone = model.Phone;
                    user.RoleAsInt = model.RoleAsInt;
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

        #region 显示用户信息

        /// <summary>
        ///  显示用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Entity.User _user = new Entity.User();
            _user = db.Users.Find(id);
            vUser user = new Models.ViewModel.vUser(_user);
            ViewBag.User = user;
            return View();
        }
        #endregion


        #region 修改用户信息
        /// <summary>
        ///  修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            bool result = HaveRightToEdit(id);
            if (result)
            {
                Entity.User user = new Entity.User();
                user = db.Users.Find(id);
                ViewBag.User = user;
                return View();
            }
            else
            {
                return Msg("你没有权利修改该用户");
            }

        }
        #endregion

        #region 执行修改用户信息
        /// <summary>
        /// 执行修改用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Edit(vUserEdit model, HttpPostedFileBase file)
        {

            Entity.User user = new Entity.User();
            user = db.Users.Find(model.ID);

            user.Username = model.Username;
            user.City = model.City;
            user.Name = model.Name;
            user.Phone = model.Phone;
            if (file != null)
            {
                System.IO.Stream stream = file.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                stream.Close();
                user.Avatar = buffer;
            }
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(model.Username, false);
            if (!string.IsNullOrEmpty(model.Password))
            {
                if (user.Password.Equals(Helper.Encryt.GetMD5(model.Password)))
                {
                    model.Password = Helper.Encryt.GetMD5(model.NewPassword);
                    db.SaveChanges();
                    return Redirect("/User/" + model.ID);
                }
                else
                {
                    db.SaveChanges();
                    ModelState.AddModelError("", "用户原始密码不正确！请输入正确的原始密码！");
                }
            }
            else
            {
                db.SaveChanges();
                return Redirect("/User/" + model.ID);
            }
            ViewBag.User = user;
            return View(model);
        }
        #endregion


        #region 注销
        /// <summary>
        ///  注销
        /// </summary>
        /// <returns></returns>
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion



        #region 当修改时查看  是不是有权利修改
        /// <summary>
        /// 当修改时查看
        /// </summary>
        /// <param name="udi"></param>
        /// <returns></returns>
        public bool HaveRightToEdit(int uid)
        {
            Entity.User user = db.Users.Find(uid);
            if (CurrentUser.Username == user.Username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}