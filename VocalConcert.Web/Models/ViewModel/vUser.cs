using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models.ViewModel
{
    public class vUser
    {
        public int ID { get; set; }

        public string  Username { get; set; }

        public string  City { get; set; }

        public byte[] Avatar { get; set; }

        public UserRole Role { get; set; }

        public string  Phone { get; set; }

        public List<Group> Groups { set; get; }

        public string Name { get; set; }

        public vUser() { }

        public vUser(User user)
        {
            this.ID = user.ID;
            this.Username = user.Username;
            this.City = user.City;
            this.Avatar = user.Avatar;
            this.Role = user.Role;
            this.Phone = user.Phone;
            this.Groups = user.Groups.ToList();
        }
    }


}