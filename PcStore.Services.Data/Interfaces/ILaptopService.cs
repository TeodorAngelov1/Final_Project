using PcStore.Data.Models;
using PcStore.Web.ViewModels.Laptop;
using PcStore.Web.ViewModels.MyCart;
namespace PcStore.Services.Data.Interfaces
{
    public interface ILaptopService
    {
        Task<IEnumerable<AllLaptopsModel>> GetAllLaptopsAsync();

        Task<bool> DeleteLaptopAsync(Guid id);

        Task<bool> AddLaptopAsync(AddLaptopModel inputModel);

        Task<EditLaptopModel> EditLaptopAsync(Guid id, EditLaptopModel model);

        Task<LaptopDetailsModel?> GetLaptopDetailsByIdAsync(Guid id);

        Task<EditLaptopModel> GetById(Guid id);

        Task<Laptop> TakeLaptop(Guid id);

    }
}
