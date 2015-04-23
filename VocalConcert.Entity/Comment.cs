using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_comment")]
    public class Comment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("userId")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 音乐ID
        /// </summary>
        [Column("musicId")]
        [ForeignKey("Music")]
        public int MusicID { get; set; }

        public virtual Music Music { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        [Column("score")]
        public int Score { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        [Column("ptime")]
        public DateTime Time { get; set; }
    }
}