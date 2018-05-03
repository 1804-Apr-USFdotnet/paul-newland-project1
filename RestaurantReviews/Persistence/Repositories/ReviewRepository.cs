using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Core.Repositories;

namespace RestaurantReviews.Persistence.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ReviewRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public void UpdateReviewDescription(int id, string description)
        {
            try
            {
                GetReview(id).Description = description;
            }
            catch (NullReferenceException e)
            {
                _logger.Error(e.Message);
            }
        }

        public void UpdateReviewRating(int id, int rating)
        {
            try
            {
                GetReview(id).Rating = rating;
            }
            catch (NullReferenceException e)
            {
                _logger.Error(e.Message);
            }
        }

        private Review GetReview(int id)
        {
            return Context.Reviews.Find(id);
        }
    }
}