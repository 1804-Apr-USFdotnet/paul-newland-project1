﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Core.Repositories;

namespace RestaurantReviews.Persistence.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Restaurant> GetTopRatedRestaurants(int count)
        {
            return Context.Restaurants
                .Include(r => r.Reviews)
                .OrderByDescending(r => GetAverageRating(r))
                .Take(count);
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameAZ()
        {
            return Context.Restaurants
                .OrderBy(r => r.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameZA()
        {
            return Context.Restaurants
                .OrderByDescending(r => r.Name);
        }

        public void UpdateRestaurantName(int id, string newName)
        {
            var r = Context.Restaurants.Find(id);
            r.Name = newName;
        }

        private double GetAverageRating(Restaurant restaurant)
        {
            return restaurant.Reviews.Average(r => r.Rating);
        }
    }
}