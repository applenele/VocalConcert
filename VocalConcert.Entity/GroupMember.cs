using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_groupmember")]
    public class GroupMember
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [ForeignKey("User")]
        [Column("userId")]
        public int UserID { get; set; }
        
        public virtual User User { get; set; }

        /// <summary>
        /// 歌友会ID
        /// </summary>
        [ForeignKey("Group")]
        [Column("groupId")]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        [Column("ptime")]
        public DateTime Time { get; set; }
    }
}