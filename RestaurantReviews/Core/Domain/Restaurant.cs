using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantReviews.Core.Domain
{
    public class Restaurant : IWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}