using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Models
{
    public class GroupMember
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
        /// 歌友会ID
        /// </summary>
        [Key]
        [ForeignKey("Group")]
        [Column(Order = 1)]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}