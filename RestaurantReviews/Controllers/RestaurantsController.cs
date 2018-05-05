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
    public class RestaurantsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantsController()
            : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            // TODO: Find a way to do dependency injection here with...
            // TODO: ...the controller taking an IUnitOfWork param...
            // TODO: ...not coming from the default constructor.
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [Route("restaurants")]
        public ActionResult Index()
        {
            var restaurants = _unitOfWork.Restaurants.GetAll();
            return User.Identity.IsAuthenticated && User.IsInRole(RoleName.CanManageRestaurants)
                ? View("IndexAdmin", restaurants)
                : View(restaurants);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("restaurants/details/{id}")]
        public ActionResult Show(int id)
        {
            var restaurant = _unitOfWork.Restaurants.Get(id);
            return View(restaurant);
        }
        
        [Authorize(Roles = RoleName.CanManageRestaurants)]
        [Route("restaurants/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("restaurants")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageRestaurants)]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("New", restaurant);

            _unitOfWork.Restaurants.Add(restaurant);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }

        [Route("restaurants/{id}/edit")]
        [Authorize(Roles = RoleName.CanManageRestaurants)]
        public ActionResult Edit(int id)
        {
            var restaurant = _unitOfWork.Restaurants.Get(id);
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("restaurants/update")]
        [Authorize(Roles = RoleName.CanManageRestaurants)]
        public ActionResult Update(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", restaurant);

            _unitOfWork.Restaurants.Update(restaurant);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }

        // really should be http delete method, not get, but priorities
        [HttpGet]
        [Route("restaurants/delete/{id}")]
        [Authorize(Roles = RoleName.CanManageRestaurants)]
        public ActionResult Delete(int id)
        {
            var restaurant = _unitOfWork.Restaurants.Get(id);
            _unitOfWork.Restaurants.Remove(restaurant);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Restaurants");
        }
    }
}