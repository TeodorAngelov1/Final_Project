using PcStore.Data.Models;
using PcStore.Web.ViewModels.Laptop;
namespace PcStore.Services.Data.Interfaces
{
    public interface ILaptopService
    {
        Task<bool> DeleteLaptopAsync(Guid id);

        Task<bool> AddLaptopAsync(AddLaptopModel inputModel);

        Task EditLaptopAsync(Guid id, EditLaptopModel model);

        Task<LaptopDetailsModel?> GetLaptopDetailsByIdAsync(Guid id);

        Task<EditLaptopModel> GetById(Guid id);

        Task<Laptop> TakeLaptop(Guid id);

        LaptopQueryModel All(
            string searchTerm = null,
            int currentPage = 1,
            int laptopsPerPage = int.MaxValue);
    }
}
