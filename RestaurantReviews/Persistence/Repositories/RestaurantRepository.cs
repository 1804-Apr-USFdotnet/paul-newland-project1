using System;
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
                .OrderByDescending(r => r.Reviews.Average(rev => rev.Rating))
                .Take(count)
                .ToList();
        }

        public IEnumerable<Restaurant> SearchRestaurantsByName(string query)
        {
            return Context.Restaurants
                .Where(r => r.Name.ToLower()
                    .Contains(query.ToLower()))
                .ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameAZ()
        {
            return Context.Restaurants
                .OrderBy(r => r.Name)
                .ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameZA()
        {
            return Context.Restaurants
                .OrderByDescending(r => r.Name)
                .ToList();
        }

        public double GetAverageRating(Restaurant restaurant)
        {
            return restaurant.Reviews.Average(r => r.Rating);
        }

        public Restaurant GetWithReviews(int id)
        {
            return Context.Restaurants.Include(r => r.Reviews).SingleOrDefault(r => r.Id == id);
        }
    }
}