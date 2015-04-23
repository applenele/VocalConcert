using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_actionAttender")]
    public class ActionAttender
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [ForeignKey("User")]
        [Column(Order = 0)]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        [Key]
        [ForeignKey("Action")]
        [Column(Order = 1)]
        public int ActionID { get; set; }

        public virtual Action Action { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        [Column("addTime")]
        public DateTime Time { get; set; }
    }
}