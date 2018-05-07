using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Persistence;
using RestaurantReviews.Persistence.Repositories;

namespace RestaurantReviews.Tests.Repositories
{
    [TestClass]
    public class ReviewRepositoryTests
    {
        private readonly ReviewRepository _reviewRepo = new ReviewRepository(new ApplicationDbContext());

        [TestMethod]
        public void GetReviewsByUserTest()
        {
            var reviews = _reviewRepo.GetReviewsByUser("817deb78-45fc-4b63-8eb0-b7fde8d627f4");

            Assert.AreEqual(reviews.Any(r => r.Id == 4), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 5), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 6), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 17), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 30), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 1), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 2), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 3), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 25), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 20), true);
        }

        [TestMethod]
        public void GetReviewsByRestaurantTest()
        {
            var reviews = _reviewRepo.GetReviewsByRestaurant(1);

            Assert.AreEqual(reviews.Any(r => r.Id == 1), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 2), true);
            Assert.AreEqual(reviews.Any(r => r.Id == 1), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 6), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 8), true);
            Assert.AreNotEqual(reviews.Any(r => r.Id == 123), true);
        }
    }
}
