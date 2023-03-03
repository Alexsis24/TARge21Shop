using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;

        public WeatherForecastsController(
            IWeatherForecastsServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather ()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }
            return View();
        }

        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();
            WeatherViewModel vm = new();

            _weatherForecastServices.WeatherDetail(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.Temperature.Minimum.Value = dto.TempMinValue;
            vm.Temperature.Minimum.Unit = dto.TempMinUnit;
            vm.Temperature.Minimum.UnitType = dto.TempMinUnitType;

            vm.Temperature.Maximum.Value = dto.TempMaxValue;
            vm.Temperature.Maximum.Unit = dto.TempMaxUnit;
            vm.Temperature.Maximum.UnitType = dto.TempMaxUnitType;

            vm.DayNightCycle.Day.Icon = dto.DayIcon;
            vm.DayNightCycle.Day.IconPhrase = dto.DayIconPhrase;
            vm.DayNightCycle.Day.HasPrecipitation = dto.DayHasPrecipitation;
            vm.DayNightCycle.Day.PrecipitationType = dto.DayPrecipitationType;
            vm.DayNightCycle.Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.DayNightCycle.Night.Icon = dto.NightIcon;
            vm.DayNightCycle.Night.IconPhrase = dto.NightIconPhrase;
            vm.DayNightCycle.Night.HasPrecipitation = dto.NightHasPrecipitation;
            vm.DayNightCycle.Night.PrecipitationType = dto.NightPrecipitationType;
            vm.DayNightCycle.Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;


            return View(vm);
        }
    }
}
