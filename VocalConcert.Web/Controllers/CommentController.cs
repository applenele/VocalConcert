using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VocalConcert.Entity;

namespace VocalConcert.Web.Controllers
{
    public class CommentController : BaseController
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(string content, int mid,int score)
        {
            if (CurrentUser == null)
            {
                return Content("nouser");
            }
            Comment comment = new Comment { UserID = CurrentUser.ID, MusicID = mid, Content = content, Time = DateTime.Now,Score=score };

            db.Comments.Add(comment);
            int result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
    }
}