using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DIneWithWebSite.Models
{
    public class VoteLog
    {
        public int ID { get; set; }
        public int SectionID { get; set; }
        public int VoteForID { get; set; }
        public string UserName { get; set; }
        public int Vote { get; set; }
        public Boolean Active { get; set; }
    }

}