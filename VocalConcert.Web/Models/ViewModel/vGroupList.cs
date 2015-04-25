using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vGroupList
    {

        [Display(Name="歌友会ID")]
        public int ID { get; set; }

        [Display(Name="歌友会标题")]
        public string Title { get; set; }

        [Display(Name="描述")]
        public string Description { get; set; }


        public int UserID { get; set; }

        public string Username { get; set; }

        [Display(Name="创建时间")]
        public string Time { get; set; }


        [Display(Name="城市")]
        public string City { get; set; }



        public vGroupList() { }

        public vGroupList(Group group)
        {

            DB db=new DB();
            this.ID = group.ID;
            this.Title = group.Title;
            this.Description = group.Description;
            this.UserID = group.UserID;
            this.Username = db.Users.Find(group.UserID).Username;
            this.Time = group.Time.ToString();
            this.City = group.City;
        }

    }
}