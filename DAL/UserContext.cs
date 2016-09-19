using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
    { }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Group { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}