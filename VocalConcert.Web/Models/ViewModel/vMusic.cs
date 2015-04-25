using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vMusic
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Lyric { get; set; }

        public string Path { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public bool RecommendMark { get; set; }

        public string Time { get; set; }

        public string Type { get; set; }

        public vMusic() { }

        public vMusic(Music music)
        {
            this.ID = music.ID;
            this.Title = music.Title;
            this.Description = music.Description;
            this.Lyric = music.Lyric;
            this.Path = music.Path;
            this.UserID = music.UserID;
            this.User = music.User;
            this.RecommendMark = music.RecommendMark;
            this.Title = Helper.Time.ToTimeTip(music.Time);
            this.Type = music.Type.ToString();
        }
    }
}