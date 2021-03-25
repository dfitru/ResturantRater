using ResturantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }
        //Get: Resturant Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Post: Restaurant Create
        [HttpPost]//this method going to be posted 
        [ValidateAntiForgeryToken]//allow server to match up with the antiforgeryToken
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)//check the model given to the method
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
    }
}