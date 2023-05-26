using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.OpenWeather;

namespace TARge21Shop.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        SearchCityViewModel vm = new SearchCityViewModel();

        public OpenWeathersController(
           IOpenWeatherServices openWeatherServices
           )
        {
            _openWeatherServices = openWeatherServices;
        }

        public IActionResult Index()
        {
            SearchCityViewModel vm = new SearchCityViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers");
            }
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            CityResultViewModel vm = new CityResultViewModel();

            dto.City = city;
            _openWeatherServices.WeatherDetail(dto);
            vm.City = city;
            vm.Timezone = dto.Timezone;
            vm.Name = dto.Name;
            vm.Lon = dto.Lon;
            vm.Lat = dto.Lat;
            vm.Temperature = dto.Temperature;
            vm.Feels_like = dto.Feels_like;
            vm.Pressure = dto.Pressure;
            vm.Humidity = dto.Humidity;
            vm.Main = dto.Main;
            vm.Description = dto.Description;
            vm.Speed = dto.Speed;

            return View(vm);
        }
    }
}
