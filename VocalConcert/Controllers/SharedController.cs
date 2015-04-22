using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VocalConcert.Helpers;
using VocalConcert.Models;

namespace VocalConcert.Controllers
{
    public class SharedController : BaseController
    {
        [Route("Message")]
        public ActionResult Message(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }

        [Route("Login")]
        [HttpGet]
        [GuestOnly]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [GuestOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            var HashedPassword = Security.SHA1(Password);
            var user = (from u in DB.Users
                        where u.Username == Username
                        && u.Password == HashedPassword
                        select u).SingleOrDefault();
            if (user == null)
                return Msg("用户名或密码错误");
            FormsAuthentication.SetAuthCookie(user.Username, false);
            return RedirectToAction("Index", "Home");
        }

        [Route("Register")]
        [HttpGet]
        [GuestOnly]
        public ActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        [GuestOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Username, string Password, string Name, string Phone, string City)
        {
            var user = (from u in DB.Users
                        where u.Username == Username
                        select u).SingleOrDefault();
            if (user != null)
                return Msg("该用户已经存在，请更换用户名后重试！");
            var usr = new User
            {
                Username = Username,
                Password = Password,
                Name = Name,
                City = City,
                Phone = Phone,
                Avatar = new byte[0],
                Role = UserRole.Member
            };
            DB.Users.Add(usr);
            DB.SaveChanges();
            return Msg("注册成功，请使用您刚刚注册的用户名密码进行登录！");
        }
    }
}