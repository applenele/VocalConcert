using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VocalConcert.Models
{
    public class VocalConcertContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<ActionAttender> ActionAttenders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }

        public VocalConcertContext() : base("mysqldb") { }
    }
}