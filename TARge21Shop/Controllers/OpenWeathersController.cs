using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Models.OpenWeather;

namespace TARge21Shop.Controllers
{
    public class OpenWeathersController : Controller
    {
        public IActionResult Index()
        {
            SearchCityViewModel vm = new SearchCityViewModel();
            return View();
        }

        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers", new { city = model.CityName });
            }
            return View(model);
        }

        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            dto.City = city;
            //CityResultViewModel vm = new();

            return View();
        }
    }
}
