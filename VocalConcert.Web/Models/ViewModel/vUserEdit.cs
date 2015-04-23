using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vUserEdit
    {
        public int ID { get; set; }

        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        public byte[] Avatar { get; set; }

        [Display(Name = "电话")]
        public string Phone { get; set; }

        [Display(Name = "真实姓名")]

        public string Name { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [Display(Name = "新密码重复")]
        [Compare("NewPassword",ErrorMessage="两次输入的密码不一致!")]
        public string NewPassword2 { get; set; }

    }
}