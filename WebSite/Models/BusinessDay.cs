using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class BusinessDay
    {
        public int ID{ get; set; }
        public DateTime open{ get; set; }
        public DateTime close { get; set; }
    }
}