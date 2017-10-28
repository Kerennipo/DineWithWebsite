using DIneWithWebSite.Models;
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
            public DbSet<VoteLog> Votes { get; set; }

        public DbSet<CommentPost> CommentPosts { get; set; }
    }
   
}