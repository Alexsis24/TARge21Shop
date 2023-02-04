using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using System.Numerics;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsServices _carsServices;
        private readonly TARge21ShopContext _context;
        public CarsController
            (
                ICarsServices carsServices,
                TARge21ShopContext context
            )
        {
            _carsServices = carsServices;
            _context = context;
        }
    
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.ListedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    PassengerCount = x.PassengerCount,
                });
            return View(result);

        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                PassengerCount = vm.PassengerCount,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuiltDate = vm.BuiltDate,
                ListedAt = vm.ListedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cars = await _carsServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel();

            vm.Id = cars.Id;
            vm.Brand = cars.Brand;
            vm.Model = cars.Model;
            vm.PassengerCount = cars.PassengerCount;
            vm.FullTripsCount = cars.FullTripsCount;
            vm.MaintenanceCount = cars.MaintenanceCount;
            vm.LastMaintenance = cars.LastMaintenance;
            vm.EnginePower = cars.EnginePower;
            vm.BuiltDate = cars.BuiltDate;
            vm.ModifiedAt = cars.ModifiedAt;
            vm.ListedAt = cars.ListedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                PassengerCount = vm.PassengerCount,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuiltDate = vm.BuiltDate,
                ListedAt = vm.ListedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var cars = await _carsServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel();

            vm.Id = cars.Id;
            vm.Brand = cars.Brand;
            vm.Model = cars.Model;
            vm.PassengerCount = cars.PassengerCount;
            vm.FullTripsCount = cars.FullTripsCount;
            vm.MaintenanceCount = cars.MaintenanceCount;
            vm.LastMaintenance = cars.LastMaintenance;
            vm.EnginePower = cars.EnginePower;
            vm.BuiltDate = cars.BuiltDate;
            vm.ModifiedAt = cars.ModifiedAt;
            vm.ListedAt = cars.ListedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _carsServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();

            vm.Id = cars.Id;
            vm.Brand = cars.Brand;
            vm.Model = cars.Model;
            vm.PassengerCount = cars.PassengerCount;
            vm.FullTripsCount = cars.FullTripsCount;
            vm.MaintenanceCount = cars.MaintenanceCount;
            vm.LastMaintenance = cars.LastMaintenance;
            vm.EnginePower = cars.EnginePower;
            vm.BuiltDate = cars.BuiltDate;
            vm.ModifiedAt = cars.ModifiedAt;
            vm.ListedAt = cars.ListedAt;

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
