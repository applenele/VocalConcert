using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Models
{
    public class Group
    {
        /// <summary>
        /// 歌友会ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 歌友会徽标
        /// </summary>
        public byte[] Icon { get; set; }

        /// <summary>
        /// 创始人用户ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}