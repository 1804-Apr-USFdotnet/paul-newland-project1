﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Core;
using RestaurantReviews.Core.Domain;
using RestaurantReviews.Persistence;
using RestaurantReviews.ViewModels;

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
        public ActionResult Index(string query = null, string sort = null)
        {
            IEnumerable<Restaurant> restaurants;

            if (query != null)
                restaurants = _unitOfWork.Restaurants.SearchRestaurantsByName(query);
            else if (sort == "AZ")
                restaurants = _unitOfWork.Restaurants.GetRestaurantsSortedByNameAZ();
            else if (sort == "ZA")
                restaurants = _unitOfWork.Restaurants.GetRestaurantsSortedByNameZA();
            else
                restaurants = _unitOfWork.Restaurants.GetAll();

            return User.Identity.IsAuthenticated && User.IsInRole(RoleName.CanManageRestaurants)
                ? View("IndexAdmin", restaurants)
                : View(restaurants);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("restaurants/details/{id}")]
        public ActionResult Show(int id)
        {
            var restaurant = _unitOfWork.Restaurants.GetWithReviews(id);
            var avgRating = _unitOfWork.Restaurants.GetAverageRating(restaurant).ToString("#.##");
            var vm = new ShowRestaurantViewModel() {Restaurant = restaurant, AverageRating = avgRating};
            return View(vm);
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