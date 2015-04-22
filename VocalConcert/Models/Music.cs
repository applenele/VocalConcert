using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Models
{
    public enum MusicType
    {
        Original, //原创
        Cover, //翻唱
        Instrument //伴奏
    }

    public class Music
    {
        /// <summary>
        /// 音乐ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        public string Lyric { get; set; }

        /// <summary>
        /// 上传用户ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 推荐标识
        /// </summary>
        public bool RecommendMark { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public MusicType Type { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}