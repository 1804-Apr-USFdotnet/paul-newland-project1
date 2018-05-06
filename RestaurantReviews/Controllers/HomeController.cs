using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Core;
using RestaurantReviews.Persistence;

namespace RestaurantReviews.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController()
            : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var restaurants = _unitOfWork.Restaurants.GetTopRatedRestaurants(3);
            return View(restaurants);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}