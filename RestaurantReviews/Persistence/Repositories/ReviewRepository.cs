using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Core.Repositories;

namespace RestaurantReviews.Persistence.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Review> GetReviewsByUser(string userId)
        {
            var user = Context.Users.Find(userId);
            return Context.Reviews.Where(r => r.UserId == user.Id).ToList();
        }

        public IEnumerable<Review> GetReviewsByRestaurant(int restaurantId)
        {
            var restaurant = Context.Restaurants.Find(restaurantId);
            return Context.Reviews.Where(r => r.RestaurantId == restaurant.Id).ToList();
        }
    }
}