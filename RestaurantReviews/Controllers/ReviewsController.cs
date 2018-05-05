using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Core;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Persistence;

namespace RestaurantReviews.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController()
            : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            // TODO: Find a way to do dependency injection here with...
            // TODO: ...the controller taking an IUnitOfWork param...
            // TODO: ...not coming from the default constructor.
            _unitOfWork = unitOfWork;
        }

        [Route("restaurants/{restaurantId}/reviews")]
        public ActionResult RestaurantReviewsIndex(int restaurantId)
        {
            var reviews = _unitOfWork.Reviews.GetReviewsByRestaurant(restaurantId);
            return View(reviews);
        }

        [Route("users/{userId}/reviews")]
        public ActionResult UserReviewsIndex(int userId)
        {
            var reviews = _unitOfWork.Reviews.GetReviewsByUser(userId);
            return View(reviews);
        }

        [Route("reviews/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        [Route("reviews/{id}")]
        public ActionResult Show(int id)
        {
            var review = _unitOfWork.Reviews.Get(id);
            return View(review);
        }

        [HttpPost]
        [Route("reviews")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("New", review);

            _unitOfWork.Reviews.Add(review);
            _unitOfWork.Complete();

            return RedirectToAction("UserReviewsIndex", "Reviews");
        }

        [Route("reviews/{id}/edit")]
        public ActionResult Edit(int id)
        {
            var review = _unitOfWork.Reviews.Get(id);
            return View(review);
        }

        [HttpPost]
        [Route("reviews/update")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Review review)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", review);

            _unitOfWork.Reviews.Update(review);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }

        // really should be a delete method, not get, but priorities
        [HttpGet]
        [Route("reviews/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var restaurant = _unitOfWork.Restaurants.Get(id);
            _unitOfWork.Restaurants.Remove(restaurant);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }
    }
}