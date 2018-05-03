using System.Collections.Generic;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Core.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        void UpdateReviewDescription(int id, string description);
        void UpdateReviewRating(int id, int rating);
    }
}
