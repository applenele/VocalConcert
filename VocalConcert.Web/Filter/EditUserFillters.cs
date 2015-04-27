using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;
using VocalConcert.Web.Models;

namespace VocalConcert.Web.Filter
{
    public class EditUserFillter : FilterAttribute, IActionFilter
    {
        private bool flag = false;

        public EditUserFillters(int uid)
        {
            DB db = new DB();
            User user = db.Users.Find(uid);
            if (HttpContext.Current.User.Identity.Name == user.Username)
            {
                flag = true;
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                filterContext.HttpContext.Response.Redirect("/Shared/Message?msg=你没有权限修改该用户!",true);
            }
        }
    }
}