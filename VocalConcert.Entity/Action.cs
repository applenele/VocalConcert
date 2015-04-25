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
        [Required]
        [Display(Name = "活动标题")]
        public string Title { get; set; }


        /// <summary>
        /// 活动描述
        /// </summary>
        [Required]
        [Display(Name="描述")]
        public string Description { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        [Display(Name = "开始时间")]
        public DateTime Begin { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Required]
        [Display(Name="结束时间")]
        public DateTime End { get; set; }

        /// <summary>
        /// 发起活动的时间
        /// </summary>
        [Display(Name = "活动发起时间")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Hint { get; set; }

        //public virtual ICollection<User> Attenders { get; set; }
    }
}