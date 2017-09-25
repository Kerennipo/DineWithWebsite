using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Comment
    {
        public int ID{ get; set; }
        public int RelatedPost { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string WebSite { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }

    }

}