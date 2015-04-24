using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vGroup
    {
        [Display(Name="歌友会ID")]
        public int ID { get; set; }

        [Display(Name="歌友会标题")]
        public string Title { get; set; }

        [Display(Name="描述")]
        public string Description { get; set; }


        public int UserID { get; set; }

        public User User { get; set; }

        [Display(Name="创建时间")]
        public string Time { get; set; }


        [Display(Name="城市")]
        public string City { get; set; }

        public List<vUser> Attenders { get; set; }


        public vGroup() { }

        public vGroup(Group group)
        {

            DB db=new DB();
            this.ID = group.ID;
            this.Title = group.Title;
            this.Description = group.Description;
            this.UserID = group.UserID;
            this.User = db.Users.Find(group.UserID);
            this.Time = group.Time.ToString();
            this.City = group.City;
            List<GroupMember> gms = new List<GroupMember>();
            Attenders = new List<vUser>();
            gms = db.GroupMembers.Where(gm=>gm.GroupID==group.ID).ToList();
            foreach (var gm in gms)
            {
                Attenders.Add(new vUser(gm.User));
            }
        }


    }
}