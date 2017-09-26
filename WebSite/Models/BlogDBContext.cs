using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
  
        public class BlogDBContext : DbContext
        { 
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
   
}