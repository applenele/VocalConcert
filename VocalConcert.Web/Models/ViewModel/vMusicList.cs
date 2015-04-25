﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vMusicList
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public bool RecommendMark { get; set; }

        public string Time { get; set; }

        public vMusicList() { }

        public vMusicList(Music music)
        {
            this.ID = music.ID;
            this.Title = music.Title;
            this.Description = music.Description;
            this.Username = music.User.Username;
            this.RecommendMark = music.RecommendMark;
            this.Time = Helper.Time.ToTimeTip(music.Time);
        }
    }
}