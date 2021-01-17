using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        Restaurant GetRestaurantById(int id);
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

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

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);
        }
    }
}
