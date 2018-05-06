using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.ViewModels
{
    public class ShowRestaurantViewModel
    {
        public Restaurant Restaurant { get; set; }
        public string AverageRating { get; set; }
    }
}