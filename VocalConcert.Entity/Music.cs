using System;
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
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name="歌名")]
        public string Title { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Display(Name="描述")]
        public string Description { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        [Display(Name="歌词")]
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
        [Display(Name="是否推荐")]
        public bool RecommendMark { get; set; }

      
        public string Path { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime Time { get; set; }

        [Display(Name="音乐类型")]
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