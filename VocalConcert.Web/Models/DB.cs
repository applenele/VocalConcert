using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VocalConcert.Entity;

namespace VocalConcert.Web.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("mysqldb")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Entity.Action> Actions { get; set; }
        public DbSet<ActionAttender> ActionAttenders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Discussion> Discussions { get; set; }

        
      
    }
}