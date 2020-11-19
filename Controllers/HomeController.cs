using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;


namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll()
            };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
                return RedirectToAction(nameof (Index));

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var newRestaurant = new Restaurant 
                {
                    Name = model.Name, 
                    Cuisine = model.Cuisine
                };

            newRestaurant = _restaurantData.Add(newRestaurant);

            return RedirectToAction(nameof(Details), new {id = newRestaurant.Id});
        }
    }
}
