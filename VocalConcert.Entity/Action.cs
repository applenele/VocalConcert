using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_action")]
    public class Action
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 歌友会ID
        /// </summary>
        [Column("groupId")]
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// 活动发起人ID
        /// </summary>
        [Column("userId")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 活动标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("begin")]
        public DateTime Begin { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("hint")]
        public string Hint { get; set; }

        public virtual ICollection<User> Attenders { get; set; }
    }
}