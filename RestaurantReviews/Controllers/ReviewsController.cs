using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
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

        [Route("reviews/new")]
        public ActionResult New()
        {
            return View();
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

            return RedirectToAction("Index", "Restaurants");
        }

        [Route("reviews/{id}/edit")]
        public ActionResult Edit(int id)
        {
            var review = _unitOfWork.Reviews.Get(id);
            if (User.Identity.GetUserId() == review.UserId || User.IsInRole(RoleName.CanManageRestaurants))
                return View(review);
            return RedirectToAction("Index", "Restaurants");
        }

        [HttpPost]
        [Route("reviews/update")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Review review)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", review);
            if (User.Identity.GetUserId() != review.UserId && !User.IsInRole(RoleName.CanManageRestaurants))
                return RedirectToAction("Index", "Restaurants");
            _unitOfWork.Reviews.Update(review);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");

        }

        // really should be a delete method, not get, but priorities
        [HttpGet]
        [Route("reviews/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var review = _unitOfWork.Reviews.Get(id);
            if (User.Identity.GetUserId() != review.UserId || !User.IsInRole(RoleName.CanManageRestaurants))
                return RedirectToAction("Index", "Restaurants");
            _unitOfWork.Reviews.Remove(review);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }
    }
}