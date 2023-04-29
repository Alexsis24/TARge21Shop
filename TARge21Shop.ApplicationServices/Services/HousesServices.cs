using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class HousesServices : IHousesServices
    {
        private readonly TARge21ShopContext _context;

        public HousesServices
        (
            TARge21ShopContext context
        )
        {
            _context = context;
        }

        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.BuildingType = dto.BuildingType;
            house.Address = dto.Address;
            house.Country = dto.Country;
            house.City = dto.City;
            house.State = dto.State;
            house.ListedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();
            return house;
        }

        public async Task<House> Update(HouseDto dto)
        {
            var domain = new House()
            {
                Id = dto.Id,
                BuildingType = dto.BuildingType,
                Address = dto.Address,
                Country = dto.Country,
                City = dto.City,
                State = dto.State,
                ListedAt = dto.ListedAt,
                ModifiedAt = DateTime.Now
            };

            _context.Houses.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<House> Delete(Guid id)
        {
            var houseId = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Houses.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }

        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

    }
}
