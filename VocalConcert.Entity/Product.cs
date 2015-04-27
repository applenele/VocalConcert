using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    [Table("t_product")]
    public class Product
    {
        /// <summary>
        /// 优惠产品ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 优惠产品标题
        /// </summary>
        [Display(Name="标题")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 优惠内容
        /// </summary>
        [Display(Name="描述")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 宣传图标
        /// </summary>
        [Display(Name="图标")]
        public byte[] Icon { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Display(Name="开始时间")]
        [Required]
        public DateTime Begin { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Display(Name="结束时间")]
        [Required]
        public DateTime End { get; set; }

        public DateTime Time { get; set; }

        [Display(Name="城市")]
        [Required]
        public string City { get; set; }
    }
}