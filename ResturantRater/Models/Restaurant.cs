using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResturantRater.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int Name { get; set; }
        public int Adress { get; set; }
        public int Rating { get; set; }
    }

    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}