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
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public byte[] Avatar { get; set; }

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
        public string City { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        public virtual ICollection<Group> Groups { get; set;}
    }
}