using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Houses;

namespace TARge21Shop.Controllers
{
    public class HousesController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly IHousesServices _housesServices;

        public HousesController
            (
                TARge21ShopContext context,
                IHousesServices housesServices
            )
        {
            _context = context;
            _housesServices = housesServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Houses
                .OrderByDescending(y => y.ListedAt)
                .Select(x => new HouseIndexViewModel
                {
                    Id = x.Id,
                    BuildingType = x.BuildingType,
                    Country = x.Country,
                    City = x.City,
                    State = x.State
                });
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();
            return View("CreateUpdate", house);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                BuildingType = vm.BuildingType,
                Address = vm.Address,
                Country = vm.Country,
                City = vm.City,
                State = vm.State,
                ListedAt = vm.ListedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _housesServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var house = await _housesServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseCreateUpdateViewModel();
            vm.Id = house.Id;
            vm.BuildingType = house.BuildingType;
            vm.Address = house.Address;
            vm.Country = house.Country;
            vm.City = house.City;
            vm.State = house.State;
            vm.ListedAt = house.ListedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                BuildingType = vm.BuildingType,
                Address = vm.Address,
                Country = vm.Country,
                City = vm.City,
                State = vm.State,
                ListedAt = vm.ListedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _housesServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var house = await _housesServices.GetAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDetailsViewModel();
            vm.Id = house.Id;
            vm.BuildingType = house.BuildingType;
            vm.Address = house.Address;
            vm.Country = house.Country;
            vm.City = house.City;
            vm.State = house.State;
            vm.ListedAt = house.ListedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (Guid id)
        {
            var house = await _housesServices.GetAsync (id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDeleteViewModel();

            vm.Id = house.Id;
            vm.BuildingType = house.BuildingType;
            vm.Address = house.Address;
            vm.Country = house.Country;
            vm.City = house.City;
            vm.State = house.State;
            vm.ListedAt = house.ListedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var houseId = await _housesServices.Delete(id);
            if (houseId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
            
    }
}
