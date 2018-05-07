using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantReviews.Core.Domain
{
    public class Review : IWithId
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public int RestaurantId { get; set; }


        public virtual Restaurant Restaurant { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}