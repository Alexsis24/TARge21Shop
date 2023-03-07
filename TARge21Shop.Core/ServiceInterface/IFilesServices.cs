using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Domain.CarDomains;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.Dto.CarDtos;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        //void UploadFilesToDatabase(CarDto dto, Car domain);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dto);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);

        void UploadFilesToDatabase(CarDto dto, Car domain);
        //void UploadFilesToDatabase(CarDto dto, Car domain);
        Task<CarFileToDatabase> RemoveImage(CarFileToDatabaseDto dto);
        Task<List<CarFileToDatabase>> RemoveImagesFromDatabase(CarFileToDatabaseDto[] dto);


    }
}
