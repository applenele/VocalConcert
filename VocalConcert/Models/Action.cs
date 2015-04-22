using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Models
{
    public class Action
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 歌友会ID
        /// </summary>
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// 活动发起人ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 活动标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Begin { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Hint { get; set; }

        public virtual ICollection<User> Attenders { get; set; }
    }
}