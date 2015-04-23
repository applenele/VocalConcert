using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_group")]
    public class Group
    {
        /// <summary>
        /// 歌友会ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 歌友会徽标
        /// </summary>
        [Column("icon")]
        public byte[] Icon { get; set; }

        /// <summary>
        /// 创始人用户ID
        /// </summary>
        [Column("userId")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("createTime")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Column("city")]
        public string City { get; set; }


        public virtual ICollection<User> Members { get; set; }

    }
}