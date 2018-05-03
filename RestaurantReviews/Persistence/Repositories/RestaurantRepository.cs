using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameAZ()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetRestaurantsSortedByNameZA()
        {
            throw new NotImplementedException();
        }

        public void UpdateRestaurantName(int id, string newName)
        {
            throw new NotImplementedException();
        }
    }
}