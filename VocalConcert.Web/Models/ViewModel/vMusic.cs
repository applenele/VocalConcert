using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vMusic
    {
        public int ID { get; set; }

        [Display(Name="音乐名称")]
        public string Title { get; set; }

        [Display(Name="描述")]
        public string Description { get; set; }

        [Display(Name="歌词")]
        public string Lyric { get; set; }

        public string Path { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public bool RecommendMark { get; set; }

        [Display(Name="上传时间")]
        public string Time { get; set; }

        [Display(Name="音乐类型")]
        public string Type { get; set; }

        public List<Comment> Commments { get; set; }

        [Display(Name="分数")]
        public int Score { get; set; }

       

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
            this.Time = Helper.Time.ToTimeTip(music.Time);
            this.Type = music.Type.ToString();
            this.Commments = music.Comments.OrderByDescending(m=>m.Time).ToList();

            foreach (var comment in Commments)
            {
                this.Score += comment.Score;
            }
        }
    }
}