using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    public class Discussion
    {
        /// <summary>
        /// 帖子ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 发帖人用户ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// 发帖时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 帖子内容
        /// </summary>
        public string Content { get; set; }
    }
}