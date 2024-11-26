namespace PcStore.Services.Data.Interfaces
{
    using Web.ViewModels.Laptop;
    public interface ILaptopService
    {
        Task<IEnumerable<AllPartModel>> GetAllLaptopsAsync();

        Task<bool> DeleteLaptopAsync(Guid id);

        Task<bool> AddLaptopAsync(AddPartModel inputModel);

        Task<EditPartModel> EditLaptopAsync(Guid id, EditPartModel model);

        Task<PartDetailsModel?> GetLaptopDetailsByIdAsync(Guid id);

        Task<EditPartModel> GetById(Guid id);


    }
}
