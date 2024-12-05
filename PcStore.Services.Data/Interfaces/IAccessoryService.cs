using PcStore.Data.Models;
using PcStore.Web.ViewModels.Accessories;
using PcStore.Web.ViewModels.Laptop;

namespace PcStore.Services.Data.Interfaces
{
    public interface IAccessoryService
    {
        Task<bool> DeleteAccessoryAsync(Guid id);

        Task<bool> AddAccessoryAsync(AddAccessoryModel inputModel);

        Task EditAccessoryAsync(Guid id, EditAccessoryModel model);

        Task<AccessoryDetailsModel?> GetAccessoryDetailsByIdAsync(Guid id);

        Task<EditAccessoryModel> GetById(Guid id);

        Task<Accessory> TakeAccessory(Guid id);

        AccessoryQueryModel All(
           string searchTerm = null,
           int currentPage = 1,
           int laptopsPerPage = int.MaxValue);
    }
}
