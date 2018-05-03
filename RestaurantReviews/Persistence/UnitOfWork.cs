using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantReviews.Core;
using RestaurantReviews.Core.Repositories;
using RestaurantReviews.Persistence.Repositories;

namespace RestaurantReviews.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Restaurants = new RestaurantRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public IRestaurantRepository Restaurants { get; private set; }
        public IReviewRepository Reviews { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}