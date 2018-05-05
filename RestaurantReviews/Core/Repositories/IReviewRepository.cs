using System.Collections.Generic;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Core.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewsByUser(int userId);
        IEnumerable<Review> GetReviewsByRestaurant(int restaurantId);
    }
}
