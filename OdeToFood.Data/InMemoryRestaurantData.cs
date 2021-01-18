using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                    new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian },
                    new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican }
                };
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);

            return newRestaurant;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);
        }
        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            Restaurant restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
        public Restaurant Delete(int id)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

    }
}
