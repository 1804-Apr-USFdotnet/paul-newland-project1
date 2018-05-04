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
                .OrderByDescending(r => GetAverageRating(r))
                .Take(count)
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

        public void Update(Restaurant restaurant)
        {
            var restaurantInDb = Context.Restaurants.SingleOrDefault(r => r.Id == restaurant.Id);

            //restaurantInDb.Name = restaurant.Name;
            //restaurantInDb.Phone = restaurant.Phone;
            //restaurantInDb.Street = restaurant.Street;
            //restaurantInDb.City = restaurant.City;
            //restaurantInDb.State = restaurant.State;
            //restaurantInDb.Zip = restaurant.Zip;

            Context.Entry(restaurantInDb).CurrentValues.SetValues(restaurant);
        }

        private double GetAverageRating(Restaurant restaurant)
        {
            return restaurant.Reviews.Average(r => r.Rating);
        }
    }
}