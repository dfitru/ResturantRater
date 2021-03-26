using ResturantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    
        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);//show item with the Id
            if(restaurant==null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //Post:Restaurant /Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int  id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get:Restaurant/Edit/{id}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //Post: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //Get: Resturamt/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);

        }
    }
}