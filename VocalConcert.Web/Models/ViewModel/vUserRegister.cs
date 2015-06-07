using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vUserRegister
    {
        [Required]
        [Display(Name="用户名")]
        public string Username { get; set; }

        [Required]
        [Display(Name="密码")]
        public string  Password { get; set; }

        [Required]
        [Display(Name="密码重复")]
        [Compare("Password",ErrorMessage="两次输入密码不一致！")]
        public string Password2 { get; set; }

        [Display(Name="角色")]
        public int RoleAsInt { get; set; }

        [Required]
        [Display(Name="电话")]
        
        public string Phone { get; set; }
    }
}