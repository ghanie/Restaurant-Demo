using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    

    public class InMemoryRestaurantData : IRestaurantData
    {
        // ReSharper disable once InconsistentNaming
        private readonly List<Restaurant> _restaurant;

        public InMemoryRestaurantData()
        {
            _restaurant = new List<Restaurant>
             {
                new Restaurant{Id = 1, Name = "Papa Johns Pizza"},
                new Restaurant{Id = 2, Name = "Dominos Pizza"},
                new Restaurant{Id = 3, Name = "Pizza Hut"}
             };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurant;
        }

        public Restaurant Get(int id)
        {
            return _restaurant.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurant.Max(r => r.Id) + 1;
           
            _restaurant.Add(restaurant);

            return restaurant;
        }
    }
}
