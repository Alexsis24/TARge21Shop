using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IHousesServices
    {
        Task<House> Create(HouseDto dto);
        Task<House> Update(HouseDto dto);
        Task<House> GetAsync(Guid id);
        Task<House> Delete(Guid id);
    }
}
