using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Create(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);

            return newRestaurant;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants.Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name)).OrderBy(r => r.Name);
        }
        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Attach(updatedRestaurant);

            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
        public Restaurant Delete(int id)
        {
            Restaurant restaurant = GetRestaurantById(id);

            if (restaurant != null)
            {
                db.Remove(restaurant);
            }

            return restaurant;
        }
        public int Commit()
        {
            return db.SaveChanges();
        }

    }
}