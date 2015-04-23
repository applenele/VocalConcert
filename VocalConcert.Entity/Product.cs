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
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [Column("userId")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 优惠产品标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 优惠内容
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 宣传图标
        /// </summary>
        [Column("icon")]
        public byte[] Icon { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Column("begin")]
        public DateTime Begin { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Column("end")]
        public DateTime End { get; set; }
    }
}