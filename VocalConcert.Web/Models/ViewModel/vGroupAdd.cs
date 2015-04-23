using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vGroupAdd
    {
        [Required]
        [Display(Name="名称")]
        public string Title { get; set; }

        [Required]
        [Display(Name="描述")]
        public string Description { get; set; }

        [Display(Name="徽标")]
        public byte[] Icon { set; get; }

        [Required]
        [Display(Name="城市")]
        public string City { get; set; }
    }
}