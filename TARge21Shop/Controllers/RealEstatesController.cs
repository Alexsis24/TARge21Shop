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
using TARge21Shop.Models.RealEstate;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstatesServices;
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _filesServices;

        public RealEstatesController
            (
                IRealEstatesServices realEstatesServices,
                TARge21ShopContext context,
                IFilesServices filesServices
            )
        {
            _realEstatesServices = realEstatesServices;
            _context = context;
            _filesServices = filesServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    Size = x.Size,
                    Price = x.Price,
                });
            return View(result);

        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create (RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Size = vm.Size,
                Price = vm.Price,
                Floor = vm.Floor,                
                Phone = vm.Phone,
                Fax = vm.Fax,
                RoomCount = vm.RoomCount,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.FileToApiViewModels
                    .Select(x => new FileToApiDto
                        {
                            Id = x.ImageId,
                            ExistingFilePath = x.FilePath,
                            RealEstateId = x.RealEstateId,
                        }).ToArray()
            };

            var result = await _realEstatesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstates = await _realEstatesServices.GetAsync(id);

            if (realEstates == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();
                       
            var vm = new RealEstateCreateUpdateViewModel();

                vm.Id = realEstates.Id;
                vm.Address = realEstates.Address;
                vm.City = realEstates.City;
                vm.Region = realEstates.Region;
                vm.PostalCode = realEstates.PostalCode;
                vm.Country = realEstates.Country;
                vm.Size = realEstates.Size;
                vm.Price = realEstates.Price;
                vm.Floor = realEstates.Floor;
                vm.Phone = realEstates.Phone;
                vm.Fax = realEstates.Fax;
                vm.RoomCount = realEstates.RoomCount;
                vm.CreatedAt = realEstates.CreatedAt;
                vm.ModifiedAt = realEstates.ModifiedAt;
                vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Size = vm.Size,
                Price = vm.Price,
                Floor = vm.Floor,
                Phone = vm.Phone,
                Fax = vm.Fax,
                RoomCount = vm.RoomCount,
                Files = vm.Files,
                CreatedAt = vm.CreatedAt,
                ModifiedAt= DateTime.Now,
                FileToApiDtos = vm.FileToApiViewModels
                .Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    RealEstateId = x.RealEstateId,
                }).ToArray()
            };

            var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstates = await _realEstatesServices.GetAsync(id);

            if (realEstates == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstates.Id;
            vm.Address = realEstates.Address;
            vm.City = realEstates.City;
            vm.Region = realEstates.Region;
            vm.PostalCode = realEstates.PostalCode;
            vm.Country = realEstates.Country;
            vm.Size = realEstates.Size;
            vm.Price = realEstates.Price;
            vm.Floor = realEstates.Floor;
            vm.Phone = realEstates.Phone;
            vm.Fax = realEstates.Fax;
            vm.RoomCount = realEstates.RoomCount;
            vm.CreatedAt = realEstates.CreatedAt;
            vm.ModifiedAt = realEstates.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstates = await _realEstatesServices.GetAsync(id);

            if (realEstates == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstates.Id;
            vm.Address = realEstates.Address;
            vm.City = realEstates.City;
            vm.Region = realEstates.Region;
            vm.PostalCode = realEstates.PostalCode;
            vm.Country = realEstates.Country;
            vm.Size = realEstates.Size;
            vm.Price = realEstates.Price;
            vm.Floor = realEstates.Floor;
            vm.Phone = realEstates.Phone;
            vm.Fax = realEstates.Fax;
            vm.RoomCount = realEstates.RoomCount;
            vm.CreatedAt = realEstates.CreatedAt;
            vm.ModifiedAt = realEstates.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);
                

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstateId = await _realEstatesServices.Delete(id);

            if (realEstateId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
