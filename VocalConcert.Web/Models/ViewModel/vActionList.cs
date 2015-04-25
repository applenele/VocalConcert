using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{

    /// <summary>
    /// 用于前台显示活动列表
    /// </summary>
    public class vActionList
    {
         public int ID { get; set; }

        public int GroupID { get; set; }

        public string GroupName { get; set; }

        public int UserID { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Begin { get; set; }

        public string End { set; get; }

        public string Time { get; set; }
        public string Address { set; get; }

        public string  Hint { get; set; }


        public vActionList() { }

        public vActionList(Entity.Action action)
        {
            DB db = new DB();
            this.ID = action.ID;
            this.GroupID = action.GroupID;
            this.GroupName = action.Group.Title;
            this.UserID = action.UserID;
            this.Username = action.User.Name;
            this.Title = action.Title;
            this.Description = action.Description;
            this.Begin = action.Begin.ToString();
            this.End = action.End.ToString();
            this.Address = action.Address;
            this.Hint = action.Hint;
            this.Time = action.Time.ToString();
        }
    }
}