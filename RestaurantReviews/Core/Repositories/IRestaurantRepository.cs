using System.Collections.Generic;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Core.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        IEnumerable<Restaurant> GetTopRatedRestaurants(int count);

        IEnumerable<Restaurant> GetRestaurantsSortedByNameAZ();
        IEnumerable<Restaurant> GetRestaurantsSortedByNameZA();

        double GetAverageRating(Restaurant restaurant);

        Restaurant GetWithReviews(int id);
    }
}
