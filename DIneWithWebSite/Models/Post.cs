using DIneWithWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebSite.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string WebSite { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public string Cuisine { get; set; }
        public string Meals { get; set; }
        [DisplayName("Restaurant Features")]
        public string RFeatures { get; set; }
        public string Address { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        //Opening Hours
        public string SundayOpening { get; set; }
        public string SundayClosing { get; set; }
        public string MondayOpening { get; set; }
        public string MondayClosing { get; set; }
        public string TuesdayOpening { get; set; }
        public string TuesdayClosing { get; set; }
        public string WednesdayOpening { get; set; }
        public string WednesdayClosing { get; set; }
        public string ThursdayOpening { get; set; }
        public string ThursdayClosing { get; set; }
        public string FridayOpening { get; set; }
        public string FridayClosing { get; set; }
        public string SaturdayOpening { get; set; }
        public string SaturdayClosing { get; set; }

        //Location variables
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        //Ratings
        public string Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}