using System;
using System.Collections.Generic;
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

        public void UpdateReviewDescription(int id, string description)
        {
            GetReview(id).Description = description;
        }

        public void UpdateReviewRating(int id, int rating)
        {
            GetReview(id).Rating = rating;
        }

        private Review GetReview(int id)
        {
            return Context.Reviews.Find(id);
        }
    }
}