using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vProductList
    {
        /// <summary>
        /// 优惠产品ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 优惠产品标题
        /// </summary>
        [Display(Name = "标题")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 优惠内容
        /// </summary>
        [Display(Name = "描述")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        [Required]
        public DateTime Begin { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        [Required]
        public DateTime End { get; set; }

        public string Time { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        public vProductList() { }

        public vProductList(Product product)
        {
            this.ID = product.ID;
            this.Title = product.Title;
            this.Description = product.Title;
            this.UserID = product.UserID;
            this.User = product.User;
            this.Begin = product.Begin;
            this.End = product.End;
            this.Time = Helper.Time.ToTimeTip(product.Time);
            this.City = product.City;
        }
    }
}