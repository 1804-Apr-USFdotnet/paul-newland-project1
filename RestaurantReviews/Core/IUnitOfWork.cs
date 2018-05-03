using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Core.Repositories;

namespace RestaurantReviews.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRestaurantRepository Restaurants { get; }
        IReviewRepository Reviews { get; }
        int Complete();
    }
}
