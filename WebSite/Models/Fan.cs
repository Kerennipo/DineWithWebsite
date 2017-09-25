using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebSite.Models
{
    public class Fan
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BDay { get; set; }
        public string Seniority { get; set; }

    }

    public class FanDBContext : DbContext
    {
        public DbSet<Fan> Fan { get; set; }
    }

}