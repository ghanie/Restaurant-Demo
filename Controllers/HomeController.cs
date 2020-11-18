using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using OdeToFood.ViewModels;


namespace OdeToFood.Controllers
{

    public class HomeController : Controller
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
                return RedirectToAction(nameof (Index));

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
