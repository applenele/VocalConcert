using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocalConcert.Entity
{
    public enum UserRole
    {
        Member, //普通用户
        VIP, //VIP
        Business, //商户
        Master, //管理员
        Root //系统管理员
    }

    [Table("t_user")]
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [Column("avatar")]
        public byte[] Avatar { get; set; }

        [Column("role")]
        public int RoleAsInt { set; get; }

        /// <summary>
        /// 用户角色
        /// </summary>
        [NotMapped]
        public UserRole Role
        {
            get { return (UserRole)RoleAsInt; }
            set { RoleAsInt = (int)value; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        [Column("city")]
        public string City { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column("uname")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }
    }
}