using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        Restaurant Create(Restaurant newRestaurant);
        Restaurant GetRestaurantById(int id);
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        int GetCountOfRestaurants();
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
