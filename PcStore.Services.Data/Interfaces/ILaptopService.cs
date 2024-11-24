namespace PcStore.Services.Data.Interfaces
{
    using Web.ViewModels.Laptop;
    public interface ILaptopService
    {
        Task<IEnumerable<AllLaptopsModel>> GetAllLaptopsAsync();

        Task<bool> DeleteLaptopAsync(Guid id);

        Task<bool> AddLaptopAsync(AddLaptopModel inputModel);

        Task<EditLaptopModel> EditLaptopAsync(Guid id, EditLaptopModel model);

        Task<LaptopDetailsModel?> GetLaptopDetailsByIdAsync(Guid id);

        Task<EditLaptopModel> GetById(Guid id);

    }
}
