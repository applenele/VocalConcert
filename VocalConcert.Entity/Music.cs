﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    public enum MusicType
    {
        Original, //原创
        Cover, //翻唱
        Instrument //伴奏
    }

    [Table("t_music")]
    public class Music
    {
        /// <summary>
        /// 音乐ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        [Column("lyric")]
        public string Lyric { get; set; }

        /// <summary>
        /// 上传用户ID
        /// </summary>
        [Column("userId")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 推荐标识
        /// </summary>
        [Column("recommendMark")]
        public bool RecommendMark { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [Column("uploadTime")]
        public DateTime Time { get; set; }

        [Column("musicType")]
        public int TypeAsInt { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [NotMapped]
        public MusicType Type 
        {
            get { return (MusicType)TypeAsInt; }
            set { TypeAsInt = (int)value; }
        }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}