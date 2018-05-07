using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Persistence;
using RestaurantReviews.Persistence.Repositories;

namespace RestaurantReviews.Tests.Repositories
{
    [TestClass]
    public class RestaurantRepositoryTests
    {
        private readonly RestaurantRepository _restaurantRepo = new RestaurantRepository(new ApplicationDbContext());

        [TestMethod]
        public void GetTopRatedRestaurantsTest()
        {
            var restaurants = _restaurantRepo.GetTopRatedRestaurants(3);

            Assert.AreEqual(restaurants.Count(), 3);
            Assert.AreEqual(_restaurantRepo.GetAverageRating(restaurants.First()) >
                            _restaurantRepo.GetAverageRating(restaurants.Last()), true);
            Assert.AreNotEqual(restaurants.Count(), 4);
            Assert.AreNotEqual(restaurants.Count(), 2);
        }

        [TestMethod]
        public void SearchRestaurantsByNameTest()
        {
            var restaurants = _restaurantRepo.SearchRestaurantsByName("chi");

            Assert.AreEqual(restaurants.Count(), 2);
            Assert.AreEqual(restaurants.Any(r => r.Name == "Chipotle"), true);
            Assert.AreNotEqual(restaurants.Count(), 3);
            Assert.AreNotEqual(restaurants.Count(), 1);
            Assert.AreNotEqual(restaurants.Any(r => r.Name == "McDonalds"), true);
        }

        [TestMethod]
        public void GetRestaurantsSortedByNameAZTest()
        {
            var restaurants = _restaurantRepo.GetRestaurantsSortedByNameAZ();

            Assert.AreEqual(restaurants.Count(), 10);
        }

        [TestMethod]
        public void GetRestaurantsSortedByNameZATest()
        {
            var restaurants = _restaurantRepo.GetRestaurantsSortedByNameZA();

            Assert.AreEqual(restaurants.Count(), 10);
        }

        [TestMethod]
        public void GetAverageRatingTest()
        {
            var restaurant = _restaurantRepo.Get(1);
            var avgRating = _restaurantRepo.GetAverageRating(restaurant);

            Assert.AreEqual(avgRating < 5.0 && avgRating > 4.0, true);
        }

        [TestMethod]
        public void GetWithReviewsTest()
        {
            var restaurant = _restaurantRepo.GetWithReviews(1);

            Assert.AreEqual(restaurant.Reviews.First().Rating, 2);
        }
}
}
