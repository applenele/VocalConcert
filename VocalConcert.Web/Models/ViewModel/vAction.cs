using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vAction
    {
        public int ID { get; set; }

        public int GroupID { get; set; }

        public Group Group { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        [Display(Name="活动名称")]
        public string Title { get; set; }

        [Display(Name="描述")]
        public string Description { get; set; }

        [Display(Name="开始时间")]
        public string Begin { get; set; }

        [Display(Name="结束时间")]
        public string End { set; get; }

        [Display(Name="发起时间")]
        public string Time { get; set; }

        [Display(Name="地址")]
        public string Address { set; get; }

        [Display(Name="备注")]
        public string  Hint { get; set; }


        public List<vUser> Users { get; set; }

        public vAction() { }

        public vAction(Entity.Action action)
        {
            DB db = new DB();
            this.ID = action.ID;
            this.GroupID = action.GroupID;
            this.Group = action.Group;
            this.UserID = action.UserID;
            this.User = action.User;
            this.Title = action.Title;
            this.Description = action.Description;
            this.Begin = action.Begin.ToString();
            this.End = action.End.ToString();
            this.Address = action.Address;
            this.Hint = action.Hint;
            this.Time = action.Time.ToString();
            List<ActionAttender> aas = new List<ActionAttender>();
            Users = new List<vUser>();
            aas = db.ActionAttenders.Where(aa => aa.ActionID == action.ID).ToList();
            foreach (var aa in aas)
            {
                Users.Add(new vUser(aa.User));
            }
            
        }
    }
}