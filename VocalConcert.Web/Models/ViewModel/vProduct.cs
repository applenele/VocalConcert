using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vProduct
    {
        /// <summary>
        /// 优惠产品ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int UserID { get; set; }

        public User User { get; set; }

        /// <summary>
        /// 优惠产品标题
        /// </summary>
        [Display(Name = "标题")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///  活动状态
        /// </summary>
        public int StatusAsInt { get; set; }

        public ProductStatus Status
        {
            get { return (ProductStatus)StatusAsInt; }
            set { StatusAsInt = (int)StatusAsInt; }
        }


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
        public string Begin { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public string End { get; set; }

        [Display(Name="发布时间")]
        public string Time { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        public vProduct() { }

        public vProduct(Product product)
        {
            this.ID = product.ID;
            this.Title = product.Title;
            this.Description = product.Description;
            this.UserID = product.UserID;
            this.User = product.User;
            this.Begin = product.Begin.ToString();
            this.End = product.End.ToString();
            this.Time = Helper.Time.ToTimeTip(product.Time);
            this.City = product.City;

            if (DateTime.Now < product.Begin)
            {
                this.StatusAsInt = 0;
            }
            else if (DateTime.Now > product.End)
            {
                this.StatusAsInt = 2;
            }
            else if (DateTime.Now >= product.Begin && DateTime.Now <= product.End)
            {
                this.StatusAsInt = 1;
            }
        }
    }
}