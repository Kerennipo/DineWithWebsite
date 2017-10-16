using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace DIneWithWebSite.Models
{
    public class CommentPost
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        [DisplayName("Review")]
        public string Content { get; set; }
        public int RelatedPostId { get; set; }
        [DisplayName("Restaurant")]
        public string PostName { get; set; }
        

        public CommentPost()
        {

        }
        public CommentPost(Comment comment, Post post)
        {
            this.ID = post.ID;
            this.Name = comment.Writer;
            this.Title = comment.Title;
            this.Content = comment.Content;
            this.RelatedPostId = post.ID;
            this.PostName = post.Title;
        }

    }
}