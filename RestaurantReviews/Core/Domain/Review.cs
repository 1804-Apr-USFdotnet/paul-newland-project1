using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantReviews.Core.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}